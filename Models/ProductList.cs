using ProvaPub.Interfaces;

namespace ProvaPub.Models
{
    public class ProductList : IBaseList<Product>
    {
        public List<Product>? Items { get; set; }
        public int TotalCount { get; set; }
        public bool HasNext { get; set; }
    }
}
