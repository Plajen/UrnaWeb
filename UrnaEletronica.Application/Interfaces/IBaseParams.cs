namespace UrnaEletronica.Application.Interfaces
{
    public interface IBaseParams
    {
        int? Skip { get; set; }
        int? Take { get; set; }
        string OrderBy { get; set; }
    }
}
