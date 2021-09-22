using UrnaEletronica.Application.ViewModels;

namespace UrnaEletronica.Application.Validations.Vote
{
    public class RemoveVoteValidation : VoteValidation<VoteViewModel>
    {
        public RemoveVoteValidation()
        {
            ValidateId();
        }
    }
}
