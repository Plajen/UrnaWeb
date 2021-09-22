using UrnaEletronica.Application.ViewModels;

namespace UrnaEletronica.Application.Validations.Vote
{
    public class RegisterNewVoteValidation : VoteValidation<VoteViewModel>
    {
        public RegisterNewVoteValidation()
        {
            ValidateCandidateId();
        }
    }
}
