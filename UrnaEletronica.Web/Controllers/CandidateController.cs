using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using UrnaEletronica.Application.ViewModels;
using UrnaEletronica.Web.Services.Interfaces;

namespace UrnaEletronica.Web.Controllers
{
    public class CandidateController : BaseController
    {
        public CandidateController(IUrnaEletronicaApiService urnaEletronicaApi) : base(urnaEletronicaApi)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var candidates = (await UrnaEletronicaApi.GetCandidate()).Data;

            return View(candidates);
        }

        [HttpPost]
        public async Task<IActionResult> New(CandidateViewModel candidate)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var response = await UrnaEletronicaApi.SaveCandidate(candidate, HttpMethod.Post);

            if (response == null)
            {
                Danger(generic_error_message);
                return RedirectToAction("Index");
            }

            if (response.Success)
                Success("Candidato salvo com sucesso!");
            else
                Danger(response.Errors);

            return RedirectToAction("Index");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await UrnaEletronicaApi.DeleteCandidate(id);
            if (response.Success)
                Success("Candidato removido com sucesso!");
            else
                Danger(response.Errors);

            return Ok();
        }
    }
}
