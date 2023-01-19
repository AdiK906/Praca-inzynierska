using System.Threading.Tasks;
using Convey.CQRS.Commands;
using Convey.CQRS.Events;

namespace Trill.Saga.Services
{
    public interface IMessageBroker
    {
        Task SendAsync(params ICommand[] commands);
        Task PublishAsync(params IEvent[] events);
    }
}