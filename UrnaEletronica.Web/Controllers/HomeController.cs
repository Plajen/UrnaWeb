using Microsoft.AspNetCore.Mvc;
using UrnaEletronica.Web.Services.Interfaces;

namespace UrnaEletronica.Web.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUrnaEletronicaApiService urnaEletronicaApi) : base(urnaEletronicaApi)
        {
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
