using UrnaEletronica.Application.ViewModels;

namespace UrnaEletronica.Application.Validations.Vote
{
    public class UpdateVoteValidation : VoteValidation<VoteViewModel>
    {
        public UpdateVoteValidation()
        {
            ValidateId();
            ValidateCandidateId();
            ValidateVoted();
        }
    }
}
