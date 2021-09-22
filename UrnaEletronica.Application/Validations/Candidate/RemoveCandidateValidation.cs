using UrnaEletronica.Application.ViewModels;

namespace UrnaEletronica.Application.Validations.Candidate
{
    public class RemoveCandidateValidation : CandidateValidation<CandidateViewModel>
    {
        public RemoveCandidateValidation()
        {
            ValidateId();
        }
    }
}
