using MediatR;
using System.Threading.Tasks;
using UrnaEletronica.Domain.Core.Commands;
using UrnaEletronica.Domain.Core.Events;

namespace UrnaEletronica.Domain.Core.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<TResponse> SendCommand<T, TResponse>(T command) where T : Command<TResponse>
        {
            return await _mediator.Send(command);
        }

        public async Task RaiseEvent<T>(T @event) where T : Event<Unit>
        {
            await _mediator.Publish(@event);
        }
    }
}
