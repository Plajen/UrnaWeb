using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UrnaEletronica.Application.Validations.Candidate;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace UrnaEletronica.Application.ViewModels
{
    public class CandidateViewModel : BaseViewModel
    {
        [Display(Name = "Nome do Candidato")]
        [Required(ErrorMessage = "O {0} é necessário")]
        public string FullName { get; set; }

        [Display(Name = "Nome do Vice")]
        [Required(ErrorMessage = "O {0} é necessário")]
        public string ViceName { get; set; }

        [Display(Name = "Data de Registro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data de Registro inválida")]
        [Required(ErrorMessage = "A {0} é necessária")]
        public DateTime Registered { get; set; }

        [Display(Name = "Legenda")]
        [Required(ErrorMessage = "A {0} é necessária")]
        public int Ticket { get; set; }

        [Display(Name = "Quantidade de Votos")]
        public int? VotesQty { get; set; }

        public virtual IEnumerable<VoteViewModel> Votes { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public CandidateViewModel() { }

        public CandidateViewModel(
            string fullName, 
            string viceName, 
            DateTime registered, 
            int ticket, 
            IEnumerable<VoteViewModel> votes = null)
        {
            FullName = fullName;
            ViceName = viceName;
            Registered = registered;
            Ticket = ticket;

            if (votes != null)
                Votes = votes;
        }

        public bool RegistryIsValid()
        {
            ValidationResult = new RegisterNewCandidateValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool UpdateIsValid()
        {
            ValidationResult = new UpdateCandidateValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public bool RemovalIsValid()
        {
            ValidationResult = new RemoveCandidateValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
