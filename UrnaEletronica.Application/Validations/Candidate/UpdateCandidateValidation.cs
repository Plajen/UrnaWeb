using UrnaEletronica.Application.ViewModels;

namespace UrnaEletronica.Application.Validations.Candidate
{
    public class UpdateCandidateValidation : CandidateValidation<CandidateViewModel>
    {
        public UpdateCandidateValidation()
        {
            ValidateId();
            ValidateFullName();
            ValidateViceName();
            ValidateRegistered();
            ValidateTicket();
        }
    }
}
