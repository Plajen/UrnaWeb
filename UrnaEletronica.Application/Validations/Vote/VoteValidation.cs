using FluentValidation;
using System;
using UrnaEletronica.Application.ViewModels;

namespace UrnaEletronica.Application.Validations.Vote
{
    public class VoteValidation<T> : AbstractValidator<T> where T : VoteViewModel
    {
        public VoteValidation()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.Stop;
        }

        public void ValidateId()
        {
            RuleFor(v => v.Id)
                .GreaterThan(0);
        }

        public void ValidateCandidateId()
        {
            RuleFor(v => v.CandidateId)
                .GreaterThan(0)
                .WithMessage("Candidato inválido");
        }

        protected void ValidateVoted()
        {
            RuleFor(v => v.Voted)
                .NotNull()
                .NotEmpty()
                .WithMessage("Por favor garanta que haja uma Data de Voto")
                .Must(BeAValidDate)
                .WithMessage("Data de Voto inválida");
        }

        private bool BeAValidDate(DateTime date) => !date.Equals(default);
    }
}
