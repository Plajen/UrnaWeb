using Flurl.Http;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UrnaEletronica.Application.Parameters;
using UrnaEletronica.Application.ViewModels;
using UrnaEletronica.Application.ViewModels.Response;
using UrnaEletronica.Web.Configuration.Interfaces;
using UrnaEletronica.Web.Services.Interfaces;

namespace UrnaEletronica.Web.Services
{
    public class UrnaEletronicaApiService : IUrnaEletronicaApiService
    {
        private readonly IUrnaEletronicaSettings _settings;

        public UrnaEletronicaApiService(IUrnaEletronicaSettings settings)
        {
            _settings = settings;
        }

        #region Candidate
        public async Task<BaseResponse<IList<CandidateViewModel>>> GetCandidate(
            CandidateParams parameters = null)
        {
            return await BaseRequest().Result
                .AppendPathSegment("candidate")
                .SetQueryParams(parameters)
                .GetJsonAsync<BaseResponse<IList<CandidateViewModel>>>();
        }

        public async Task<BaseResponse<CandidateViewModel>> GetCandidateById(int id)
        {
            return await BaseRequest().Result
                .AppendPathSegment("candidate")
                .AppendPathSegment(id)
                .GetJsonAsync<BaseResponse<CandidateViewModel>>();
        }

        public async Task<BaseResponse<CandidateViewModel>> SaveCandidate(
            CandidateViewModel candidate, HttpMethod method)
        {
            return await BaseRequest().Result
                .AppendPathSegment("candidate")
                .SendJsonAsync(method, candidate)
                .ReceiveJson<BaseResponse<CandidateViewModel>>();
        }
        public async Task<BaseResponse<int>> DeleteCandidate(int id)
        {
            return await BaseRequest().Result
                .AppendPathSegment("candidate")
                .AppendPathSegment(id)
                .DeleteAsync()
                .ReceiveJson<BaseResponse<int>>();
        }
        #endregion

        #region Vote
        public async Task<BaseResponse<IList<VoteViewModel>>> GetVote(
            VoteParams parameters = null)
        {
            return await BaseRequest().Result
                .AppendPathSegment("vote")
                .SetQueryParams(parameters)
                .GetJsonAsync<BaseResponse<IList<VoteViewModel>>>();
        }

        public async Task<BaseResponse<VoteViewModel>> GetVoteById(int id)
        {
            return await BaseRequest().Result
                .AppendPathSegment("vote")
                .AppendPathSegment(id)
                .GetJsonAsync<BaseResponse<VoteViewModel>>();
        }

        public async Task<BaseResponse<VoteViewModel>> SaveVote(
            VoteViewModel vote, HttpMethod method)
        {
            return await BaseRequest().Result
                .AppendPathSegment("vote")
                .SendJsonAsync(method, vote)
                .ReceiveJson<BaseResponse<VoteViewModel>>();
        }
        public async Task<BaseResponse<int>> DeleteVote(int id)
        {
            return await BaseRequest().Result
                .AppendPathSegment("vote")
                .AppendPathSegment(id)
                .DeleteAsync()
                .ReceiveJson<BaseResponse<int>>();
        }
        #endregion

        #region Private Methods
        private async Task<IFlurlRequest> BaseRequest(int timeout = 0)
        {
            var request = _settings.ApiUrl
                .AllowAnyHttpStatus()
                .AppendPathSegment("api");

            return timeout > 0 ? request.WithTimeout(timeout) : request;
        }
        #endregion
    }
}
