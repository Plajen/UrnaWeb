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
    public class CandidateAppService : ICandidateAppService
    {
        private readonly IMapper _mapper;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediatorHandler _bus;

        public CandidateAppService(
            IMapper mapper,
            ICandidateRepository candidateRepository,
            IUnitOfWork unitOfWork,
            IMediatorHandler mediatorHandler)
        {
            _mapper = mapper;
            _candidateRepository = candidateRepository;
            _unitOfWork = unitOfWork;
            _bus = mediatorHandler;
        }

        public async Task<IEnumerable<CandidateViewModel>> GetAsync(CandidateParams cParams)
        {
            Expression<Func<Candidate, bool>> filter = cParams.IsAllNullOrInvalid() ? null : cParams.Filter();

            return _mapper.Map<IEnumerable<CandidateViewModel>>(await _candidateRepository
                .GetAsync(filter, cParams.Skip, cParams.Take, cParams.OrderBy));
        }

        public async Task<CandidateViewModel> GetByIdAsync(int id)
        {
            return _mapper.Map<CandidateViewModel>(await _candidateRepository.GetOneAsync(x => x.Id == id));
        }

        public async Task<CandidateViewModel> RegisterAsync(CandidateViewModel request)
        {
            if (request.RegistryIsValid())
            {
                var candidate = _mapper.Map<Candidate>(request);

                candidate = _candidateRepository.Create(candidate);

                if (!_unitOfWork.Commit())
                {
                    await _bus.RaiseEvent(new DomainNotification("Erro", "Não foi possível criar o candidato, tente novamente mais tarde"));
                }

                return _mapper.Map<CandidateViewModel>(candidate);
            }
            else
                return null;
        }

        public async Task<CandidateViewModel> UpdateAsync(CandidateViewModel request)
        {
            if (request.UpdateIsValid())
            {
                var candidate = await _candidateRepository.GetOneAsync(x => x.Id == request.Id);

                if (candidate == null)
                    return null;

                candidate = new Candidate(
                    request.Id,
                    request.FullName,
                    request.ViceName,
                    request.Registered,
                    request.Ticket);

                candidate = _candidateRepository.Update(candidate);

                if (!_unitOfWork.Commit())
                {
                    await _bus.RaiseEvent(new DomainNotification("Erro", "Não foi possível atualizar o candidato, tente novamente mais tarde"));
                }

                return _mapper.Map<CandidateViewModel>(candidate);
            }
            else
                return null;
        }

        public async Task<int> RemoveAsync(int id)
        {
            var candidate = await _candidateRepository.GetOneAsync(x => x.Id == id);
            if (candidate == null)
                return 0;

            if (_mapper.Map<CandidateViewModel>(candidate).RemovalIsValid())
                _candidateRepository.DeleteById(id);

            if (!_unitOfWork.Commit())
            {
                await _bus.RaiseEvent(new DomainNotification("Id", "Não foi possível remover o candidato, tente novamente mais tarde"));
            }

            return candidate.Id;
        }
    }
}
