using System;
using System.ComponentModel.DataAnnotations;
using UrnaEletronica.Application.Validations.Vote;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace UrnaEletronica.Application.ViewModels
{
    public class VoteViewModel : BaseViewModel
    {
        [Display(Name = "Candidato")]
        [Required(ErrorMessage = "O {0} é necessário")]
        public int CandidateId { get; set; }

        [Display(Name = "Data de Voto")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data de Voto inválida")]
        [Required(ErrorMessage = "A {0} é necessária")]
        public DateTime Voted { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public VoteViewModel(int candidateId, DateTime voted)
        {
            CandidateId = candidateId;
            Voted = voted;
        }

        public VoteViewModel() { }

        public bool RegistryIsValid()
        {
            ValidationResult = new RegisterNewVoteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool UpdateIsValid()
        {
            ValidationResult = new UpdateVoteValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool RemovalIsValid()
        {
            ValidationResult = new RemoveVoteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
