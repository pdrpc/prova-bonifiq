using Microsoft.AspNetCore.Mvc;

namespace ProvaPub.Interfaces
{
    public interface IBaseService<T>
    {
        Task<T> GetList(int page);
    }
}
