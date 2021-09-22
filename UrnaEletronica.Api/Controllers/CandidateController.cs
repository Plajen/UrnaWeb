using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrnaEletronica.Application.Interfaces;
using UrnaEletronica.Application.Parameters;
using UrnaEletronica.Application.ViewModels;
using UrnaEletronica.Application.ViewModels.Response;
using UrnaEletronica.Domain.Core.Bus;
using UrnaEletronica.Domain.Core.Notifications;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UrnaEletronica.Api.Controllers
{
    public class CandidateController : ApiController
    {
        private readonly ICandidateAppService _candidateAppService;

        public CandidateController(
            ICandidateAppService candidateAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _candidateAppService = candidateAppService;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<CandidateViewModel>>> Get([FromQuery] CandidateParams parameters)
        {
            var data = await _candidateAppService.GetAsync(parameters);
            return BaseResponse(data, null, null, parameters);
        }

        [HttpGet("{id:int}")]
        public async Task<BaseResponse<CandidateViewModel>> Get(int id)
        {
            return BaseResponse(await _candidateAppService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<BaseResponse<CandidateViewModel>> Post([FromBody] CandidateViewModel candidate)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return BaseResponse(candidate);
            }

            return BaseResponse(await _candidateAppService.RegisterAsync(candidate));
        }

        [HttpPut]
        public async Task<BaseResponse<CandidateViewModel>> Put([FromBody] CandidateViewModel candidate)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return BaseResponse(candidate);
            }
            return BaseResponse(await _candidateAppService.UpdateAsync(candidate));
        }

        [HttpDelete("{id:int}")]
        public async Task<BaseResponse<int>> Delete(int id)
        {
            return BaseResponse(await _candidateAppService.RemoveAsync(id));
        }
    }
}
