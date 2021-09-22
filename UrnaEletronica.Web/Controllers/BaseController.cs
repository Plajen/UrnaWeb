using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using UrnaEletronica.Application.ViewModels.Response;
using UrnaEletronica.Web.Extensions;
using UrnaEletronica.Web.Models;
using UrnaEletronica.Web.Services.Interfaces;

namespace UrnaEletronica.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IUrnaEletronicaApiService UrnaEletronicaApi;
        protected readonly SelectListItem FirstSelectListItemSearch;
        protected readonly SelectListItem FirstSelectListItemSelect;

        protected const string generic_error_message = "Ocorreu um erro enquanto processávamos seu pedido. Tente novamente.";

        public BaseController(IUrnaEletronicaApiService urnaEletronicaApi)
        {
            UrnaEletronicaApi = urnaEletronicaApi;
        }

        protected void Success(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Success, AlertIcon.Success, message, dismissable);
        }

        protected void Information(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Information, AlertIcon.Information, message, dismissable);
        }

        protected void Warning(string message, bool dismissable = true)
        {
            AddAlert(AlertStyles.Warning, AlertIcon.Warning, message, dismissable);
        }

        protected void Danger(string message = null, bool dismissable = true)
        {
            message = message ?? "Ocorreu um erro e não conseguimos processar seu pedido.";
            AddAlert(AlertStyles.Danger, AlertIcon.Danger, message, dismissable);
        }

        protected void Danger(IList<BaseResponseError> errors, bool dismissable = true)
        {
            if (errors == null)
                Danger("Ocorreu um erro. Por favor, tente novamente.");
            else
                Danger(string.Join("<br/>", errors.Select(x => x.Message)), dismissable);
        }

        protected void Danger(ModelStateDictionary modelState, bool dismissable = true)
        {
            if (!modelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                Danger(string.Join("<br/>", errors.Select(x => x.Exception == null ? x.ErrorMessage : x.Exception.Message)), dismissable);
            }
        }

        private void AddAlert(string alertStyle, string alertIcon, string message, bool dismissable)
        {
            var alerts = TempData.DeserializeAlerts(Alert.TempDataKey);

            alerts.Add(new Alert
            {
                AlertStyle = alertStyle,
                Message = message,
                Dismissable = dismissable,
                AlertIcon = alertIcon
            });

            TempData.SerializeAlerts(Alert.TempDataKey, alerts);
        }
    }
}
