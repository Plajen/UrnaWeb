using System.Collections.Generic;
using System.Threading.Tasks;
using UrnaEletronica.Application.Parameters;
using UrnaEletronica.Application.ViewModels;

namespace UrnaEletronica.Application.Interfaces
{
    public interface ICandidateAppService
    {
        Task<IEnumerable<CandidateViewModel>> GetAsync(CandidateParams cParams);
        Task<CandidateViewModel> GetByIdAsync(int id);
        Task<CandidateViewModel> RegisterAsync(CandidateViewModel request);
        Task<int> RemoveAsync(int id);
        Task<CandidateViewModel> UpdateAsync(CandidateViewModel request);
    }
}