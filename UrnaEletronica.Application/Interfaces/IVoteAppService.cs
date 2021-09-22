using System.Collections.Generic;
using System.Threading.Tasks;
using UrnaEletronica.Application.Parameters;
using UrnaEletronica.Application.ViewModels;

namespace UrnaEletronica.Application.Interfaces
{
    public interface IVoteAppService
    {
        Task<IEnumerable<VoteViewModel>> GetAsync(VoteParams cParams);
        Task<VoteViewModel> GetByIdAsync(int id);
        Task<int> GetCountAsync(VoteParams cParams);
        Task<VoteViewModel> RegisterAsync(VoteViewModel request);
        Task<int> RemoveAsync(int id);
        Task<VoteViewModel> UpdateAsync(VoteViewModel request);
    }
}