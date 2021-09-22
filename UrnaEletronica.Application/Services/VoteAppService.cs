using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UrnaEletronica.Application.Extensions;
using UrnaEletronica.Application.Interfaces;
using UrnaEletronica.Application.Parameters;
using UrnaEletronica.Application.ViewModels;
using UrnaEletronica.Domain.Core.Bus;
using UrnaEletronica.Domain.Core.Notifications;
using UrnaEletronica.Domain.Interfaces;
using UrnaEletronica.Domain.Models;

namespace UrnaEletronica.Application.Services
{
    public class VoteAppService : IVoteAppService
    {
        private readonly IMapper _mapper;
        private readonly IVoteRepository _voteRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediatorHandler _bus;

        public VoteAppService(
            IMapper mapper,
            IVoteRepository voteRepository,
            IUnitOfWork unitOfWork,
            IMediatorHandler mediatorHandler)
        {
            _mapper = mapper;
            _voteRepository = voteRepository;
            _unitOfWork = unitOfWork;
            _bus = mediatorHandler;
        }

        public async Task<IEnumerable<VoteViewModel>> GetAsync(VoteParams cParams)
        {
            Expression<Func<Vote, bool>> filter = cParams.IsAllNullOrInvalid() ? null : cParams.Filter();

            return _mapper.Map<IEnumerable<VoteViewModel>>(await _voteRepository
                .GetAsync(filter, cParams.Skip, cParams.Take, cParams.OrderBy));
        }

        public async Task<VoteViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<VoteViewModel>(await _voteRepository.GetOneAsync(x => x.Id == id));
        }

        public async Task<int> GetCountAsync(VoteParams cParams)
        {
            Expression<Func<Vote, bool>> filter = cParams.IsAllNullOrInvalid() ? null : cParams.Filter();

            return await _voteRepository.GetCountAsync(filter);
        }

        public async Task<VoteViewModel> RegisterAsync(VoteViewModel request)
        {
            if (request.RegistryIsValid())
            {
                var vote = _mapper.Map<Vote>(request);

                vote = _voteRepository.Create(vote);

                if (!_unitOfWork.Commit())
                {
                    await _bus.RaiseEvent(new DomainNotification("Erro", "Não foi possível criar o voto, tente novamente mais tarde"));
                }

                return _mapper.Map<VoteViewModel>(vote);
            }
            else if (request.CandidateId == -1)
            {
                return new VoteViewModel();
            }
            else
                return null;
        }

        public async Task<VoteViewModel> UpdateAsync(VoteViewModel request)
        {
            if (request.UpdateIsValid())
            {
                var vote = await _voteRepository.GetOneAsync(x => x.Id == request.Id);

                if (vote == null)
                    return null;

                vote = new Vote(request.Id, request.CandidateId, request.Voted);

                vote = _voteRepository.Update(vote);

                if (!_unitOfWork.Commit())
                {
                    await _bus.RaiseEvent(new DomainNotification("Erro", "Não foi possível atualizar o voto, tente novamente mais tarde"));
                }

                return _mapper.Map<VoteViewModel>(vote);
            }
            else
                return null;
        }

        public async Task<int> RemoveAsync(int id)
        {
            var vote = await _voteRepository.GetOneAsync(x => x.Id == id);
            if (vote == null)
                return 0;

            if (_mapper.Map<VoteViewModel>(vote).RemovalIsValid())
                _voteRepository.DeleteById(id);

            if (!_unitOfWork.Commit())
            {
                await _bus.RaiseEvent(new DomainNotification("Id", "Não foi possível remover o voto, tente novamente mais tarde"));
            }

            return vote.Id;
        }
    }
}
