using MediatR;
using Microsoft.AspNetCore.Mvc;
using UrnaEletronica.Application.Interfaces;
using UrnaEletronica.Application.ViewModels.Response;
using UrnaEletronica.Domain.Core.Bus;
using UrnaEletronica.Domain.Core.Notifications;
using System.Collections.Generic;
using System.Linq;

namespace UrnaEletronica.Api.Controllers
{
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        private readonly DomainNotificationHandler _notifications;
        private readonly IMediatorHandler _mediator;

        protected ApiController(
            INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _mediator = mediator;
        }

        protected IEnumerable<DomainNotification> Notifications => _notifications.GetNotifications();

        protected BaseResponse<T> BaseResponse<T>(T data, int? dataCount = null, int? totalCount = null, IBaseParams parameters = null)
        {
            return new BaseResponse<T>(data, dataCount, totalCount, parameters, Notifications.ToList());
        }

        protected void NotifyModelStateErrors()
        {
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach (var error in errors)
            {
                var erroMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                NotifyError(string.Empty, erroMsg);
            }
        }

        protected void NotifyError(string code, string message)
        {
            _mediator.RaiseEvent(new DomainNotification(code, message));
        }

        protected bool IsValidOperation()
        {
            return (!_notifications.HasNotifications());
        }

        protected void ExcludePropertiesInValidation(params string[] properties)
        {
            if (ModelState.IsValid)
                return;

            foreach (var property in properties)
            {
                if (ModelState.ContainsKey(property))
                {
                    ModelState.Remove(property);
                }
            }
        }
    }
}
