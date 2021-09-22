using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UrnaEletronica.Application.Parameters;
using UrnaEletronica.Application.ViewModels;
using UrnaEletronica.Application.ViewModels.Response;

namespace UrnaEletronica.Web.Services.Interfaces
{
    public interface IUrnaEletronicaApiService
    {
        Task<BaseResponse<int>> DeleteCandidate(int id);
        Task<BaseResponse<int>> DeleteVote(int id);
        Task<BaseResponse<IList<CandidateViewModel>>> GetCandidate(CandidateParams parameters = null);
        Task<BaseResponse<CandidateViewModel>> GetCandidateById(int id);
        Task<BaseResponse<IList<VoteViewModel>>> GetVote(VoteParams parameters = null);
        Task<BaseResponse<VoteViewModel>> GetVoteById(int id);
        Task<BaseResponse<CandidateViewModel>> SaveCandidate(CandidateViewModel candidate, HttpMethod method);
        Task<BaseResponse<VoteViewModel>> SaveVote(VoteViewModel vote, HttpMethod method);
    }
}