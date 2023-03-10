using System.Linq;
using System.Text;
using Chronicle;
using Convey;
using Convey.Auth;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;
using Convey.CQRS.Queries;
using Convey.HTTP;
using Convey.MessageBrokers;
using Convey.MessageBrokers.CQRS;
using Convey.MessageBrokers.Outbox;
using Convey.MessageBrokers.Outbox.Mongo;
using Convey.MessageBrokers.RabbitMQ;
using Convey.Metrics.Prometheus;
using Convey.Persistence.MongoDB;
using Convey.Persistence.Redis;
using Convey.Security;
using Convey.Tracing.Jaeger;
using Convey.Tracing.Jaeger.RabbitMQ;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using TransportOrkiestraReservation.Messages.Events.External;
using TransportOrkiestraReservation.Services;
using TransportOrkiestraReservation.Models;
using TransportOrkiestraReservation.Messages.Commands.External;

namespace TransportOrkiestraReservation
{
    public static class Extensions
    {
        public static IConveyBuilder AddCore(this IConveyBuilder builder)
        {
            builder.Services
                .AddChronicle()
                .AddScoped<IMessageBroker, MessageBroker>();

            builder
                .AddCommandHandlers()
                .AddEventHandlers()
                .AddInMemoryCommandDispatcher()
                .AddInMemoryEventDispatcher()
                .AddQueryHandlers()
                .AddInMemoryQueryDispatcher()
                .AddHttpClient()
                .AddRabbitMq(plugins: p => p.AddJaegerRabbitMqPlugin())
                .AddMessageOutbox(o => o.AddMongo())
                .AddMongo()
                .AddRedis()
                .AddJwt()
                .AddPrometheus()
                .AddJaeger()
                .AddSecurity();
            

            return builder;
        }

        public static IApplicationBuilder UseCore(this IApplicationBuilder app)
        {
            app.UseJaeger()
                .UseConvey()
                .UseAccessTokenValidator()
                .UsePrometheus()
                .UseAuthentication()
                .UseRabbitMq()
                .SubscribeCommand<TransportReserve>()
                .SubscribeCommand<ReleaseTransports>();

            return app;
        }
        
        internal static CorrelationContext GetCorrelationContext(this IHttpContextAccessor accessor)
        {
            if (accessor.HttpContext is null)
            {
                return null;
            }

            if (!accessor.HttpContext.Request.Headers.TryGetValue("Correlation-Context", out var json))
            {
                return null;
            }

            var value = json.FirstOrDefault();

            return string.IsNullOrWhiteSpace(value) ? null : JsonSerializer.Deserialize<CorrelationContext>(value);
        }
        
        internal static string GetSpanContext(this IMessageProperties messageProperties, string header)
        {
            if (messageProperties is null)
            {
                return string.Empty;
            }

            if (messageProperties.Headers.TryGetValue(header, out var span) && span is byte[] spanBytes)
            {
                return Encoding.UTF8.GetString(spanBytes);
            }

            return string.Empty;
        }
    }
}