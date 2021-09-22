using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using UrnaEletronica.Web.Services.Interfaces;

namespace UrnaEletronica.Web.Controllers
{
    public class ElectionController : BaseController
    {
        public ElectionController(IUrnaEletronicaApiService urnaEletronicaApi) : base(urnaEletronicaApi)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var candidates = (await UrnaEletronicaApi.GetCandidate()).Data
                .ToList().OrderByDescending(x => x.VotesQty).ToList();

            return View(candidates);
        }
    }
}
