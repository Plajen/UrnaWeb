using MediatR;
using System;

namespace UrnaEletronica.Domain.Core.Events
{
    public abstract class Event<T> : Message<T>, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
