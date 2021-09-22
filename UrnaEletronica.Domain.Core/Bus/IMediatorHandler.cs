using MediatR;
using System.Threading.Tasks;
using UrnaEletronica.Domain.Core.Commands;
using UrnaEletronica.Domain.Core.Events;

namespace UrnaEletronica.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task<TResponse> SendCommand<T, TResponse>(T command) where T : Command<TResponse>;
        Task RaiseEvent<T>(T @event) where T : Event<Unit>;
    }
}
