using UrnaEletronica.Application.Interfaces;

namespace UrnaEletronica.Application.ViewModels.Response
{
    public class BaseResponsePagination
    {
        public string OrderBy { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int FilteredRecords { get; set; }
        public int TotalRecords { get; set; }

        public BaseResponsePagination(IBaseParams parameters, int? dataCount, int? totalCount)
        {
            OrderBy = parameters?.OrderBy ?? "default";
            SetPage(parameters?.Skip ?? 0, parameters?.Take ?? 100);  // retrieve maximum 100 records
            FilteredRecords = dataCount ?? 0;
            TotalRecords = totalCount ?? 0;
        }

        private void SetPage(int skip, int take)
        {
            PageNumber = (skip + take) / take;
            PageSize = take;
        }
    }
}
