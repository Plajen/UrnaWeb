using FluentValidation.Results;
using System;
using UrnaEletronica.Domain.Core.Events;

namespace UrnaEletronica.Domain.Core.Commands
{
    public abstract class Command<T> : Message<T>
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
