using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using UrnaEletronica.Application.Interfaces;
using UrnaEletronica.Domain.Core.Notifications;

namespace UrnaEletronica.Application.ViewModels.Response
{
    public class BaseResponse<T> : IActionResult
    {
        public bool Success { get; set; }
        public BaseResponsePagination Pagination { get; set; }
        public T Data { get; set; }
        public IList<BaseResponseError> Errors { get; set; }

        public BaseResponse() { }

        public BaseResponse(T data, int? dataCount = null, int? totalCount = null, IBaseParams parameters = null, List<DomainNotification> errors = null)
        {
            Pagination = new BaseResponsePagination(parameters, dataCount, totalCount);
            Data = data;
            Errors = new List<BaseResponseError>();
            errors?.ForEach(error =>
            {
                if (!string.IsNullOrWhiteSpace(error.Key))
                    AddError(error.Key, error.Value);
                else
                    AddError(error.Value);
            });
            Success = !Errors.Any();
        }

        public void AddError(string errorMessage) => Errors.Add(new BaseResponseError { Message = errorMessage });
        public void AddError(string errorCode, string errorMessage) => Errors.Add(new BaseResponseError { Code = errorCode, Message = errorMessage });

        public bool ShouldSerializePagination() => Success && Data is IEnumerable;
        public bool ShouldSerializeData() => Success;
        public bool ShouldSerializeErrors() => !Success;

        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)(Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            await new ObjectResult(this).ExecuteResultAsync(context);
        }
    }
}
