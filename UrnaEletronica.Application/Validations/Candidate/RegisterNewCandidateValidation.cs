using UrnaEletronica.Application.ViewModels;

namespace UrnaEletronica.Application.Validations.Candidate
{
    public class RegisterNewCandidateValidation : CandidateValidation<CandidateViewModel>
    {
        public RegisterNewCandidateValidation()
        {
            ValidateFullName();
            ValidateViceName();
            ValidateTicket();
        }
    }
}
