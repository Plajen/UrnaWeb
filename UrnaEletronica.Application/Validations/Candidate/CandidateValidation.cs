using FluentValidation;
using System;
using UrnaEletronica.Application.ViewModels;

namespace UrnaEletronica.Application.Validations.Candidate
{
    public class CandidateValidation<T> : AbstractValidator<T> where T : CandidateViewModel
    {
        public CandidateValidation()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;
        }

        public void ValidateId()
        {
            RuleFor(c => c.Id)
                .GreaterThan(0);
        }

        public void ValidateFullName()
        {
            RuleFor(c => c.FullName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor garanta que haja um Nome do Candidato");
        }

        public void ValidateViceName()
        {
            RuleFor(c => c.ViceName)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor garanta que haja um Nome do Vice");
        }

        protected void ValidateRegistered()
        {
            RuleFor(c => c.Registered)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor garanta que haja uma Data de Registro")
                .Must(BeAValidDate)
                .WithMessage("Data de Registro inválida");
        }

        public void ValidateTicket()
        {
            RuleFor(c => c.Ticket)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor garanta que haja uma Legenda")
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(99)
                .WithMessage("Legenda inválida");
        }

        private bool BeAValidDate(DateTime date) => !date.Equals(default);
    }
}
