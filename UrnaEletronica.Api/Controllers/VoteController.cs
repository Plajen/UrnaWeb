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
    public class VoteController : ApiController
    {
        private readonly IVoteAppService _voteAppService;

        public VoteController(
            IVoteAppService voteAppService,
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {
            _voteAppService = voteAppService;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<VoteViewModel>>> Get([FromQuery] VoteParams parameters)
        {
            var data = await _voteAppService.GetAsync(parameters);
            var dataCount = await _voteAppService.GetCountAsync(parameters);
            var totalCount = await _voteAppService.GetCountAsync(new VoteParams());
            return BaseResponse(data, dataCount, totalCount, parameters);
        }

        [HttpGet("{id:int}")]
        public async Task<BaseResponse<VoteViewModel>> Get(int id)
        {
            return BaseResponse(await _voteAppService.GetByIdAsync(id));
        }

        [HttpGet("count")]
        public async Task<BaseResponse<int>> Count([FromQuery] VoteParams parameters)
        {
            return BaseResponse(await _voteAppService.GetCountAsync(parameters));
        }

        [HttpPost]
        public async Task<BaseResponse<VoteViewModel>> Post([FromBody] VoteViewModel vote)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return BaseResponse(vote);
            }

            return BaseResponse(await _voteAppService.RegisterAsync(vote));
        }

        [HttpPut]
        public async Task<BaseResponse<VoteViewModel>> Put([FromBody] VoteViewModel vote)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return BaseResponse(vote);
            }
            return BaseResponse(await _voteAppService.UpdateAsync(vote));
        }

        [HttpDelete("{id:int}")]
        public async Task<BaseResponse<int>> Delete(int id)
        {
            return BaseResponse(await _voteAppService.RemoveAsync(id));
        }
    }
}
