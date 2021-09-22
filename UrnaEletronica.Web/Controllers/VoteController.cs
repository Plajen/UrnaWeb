using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UrnaEletronica.Application.Parameters;
using UrnaEletronica.Application.ViewModels;
using UrnaEletronica.Web.Services.Interfaces;

namespace UrnaEletronica.Web.Controllers
{
    public class VoteController : BaseController
    {
        private static readonly List<int> AllValidTickets = new List<int>();

        public VoteController(IUrnaEletronicaApiService urnaEletronicaApi) : base(urnaEletronicaApi)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allCandidates = UrnaEletronicaApi.GetCandidate().Result.Data;

            if (allCandidates != null)
            {
                foreach (var candidate in allCandidates)
                {
                    AllValidTickets.Add(candidate.Ticket);
                }
            }

            return View(new VoteViewModel());
        }

        [HttpGet]
        public async Task<IActionResult> CheckTicket(int ticket)
        {
            if (AllValidTickets.Contains(ticket))
            {
                return await UrnaEletronicaApi.GetCandidate(new CandidateParams()
                {
                    Ticket = ticket
                });
            }
            else
                return null;
        }

        [HttpPost]
        public async Task<IActionResult> New(VoteViewModel vote)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var response = await UrnaEletronicaApi.SaveVote(vote, HttpMethod.Post);

            if (response == null)
            {
                Danger(generic_error_message);
                return RedirectToAction("Index");
            }

            if (response.Success)
                Success("Voto salvo com sucesso!");
            else
                Danger(response.Errors);

            return RedirectToAction("Index");
        }
    }
}
