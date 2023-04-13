namespace ProvaPub.Interfaces
{
    public interface IBaseList<T>
    {
        List<T>? Items { get; set; }
        bool HasNext { get; set; }
        int TotalCount { get; set; }
    }
}