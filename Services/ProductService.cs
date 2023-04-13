using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class ProductService : IBaseService<ProductList>
    {
        TestDbContext _ctx;

        public ProductService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ProductList> GetList(int page)
        {
            const int pageSize = 10;
            if (page == 0) page = 1;
            var totalCount = _ctx.Products.Count();
            var hasNext = (page * pageSize) < totalCount;
            var products = await _ctx.Products.Skip(pageSize * (page -1)).Take(pageSize).ToListAsync();
            var productsList = new ProductList { Items = products, TotalCount = totalCount, HasNext = hasNext};
            return productsList;
        }
    }
}
