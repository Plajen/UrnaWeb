namespace UrnaEletronica.Web.Models
{
    public class Alert
    {
        public const string TempDataKey = "TempDataAlerts";

        public string AlertStyle { get; set; }
        public string AlertIcon { get; set; }
        public string Message { get; set; }
        public bool Dismissable { get; set; }
    }

    public static class AlertStyles
    {
        public const string Success = "success";
        public const string Information = "info";
        public const string Warning = "warning";
        public const string Danger = "danger";
    }

    public static class AlertIcon
    {
        public const string Success = "la la-check";
        public const string Information = "la la-info";
        public const string Warning = "la la-warning";
        public const string Danger = "la la-info-circle";
    }
}
