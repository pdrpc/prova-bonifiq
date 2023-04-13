using Microsoft.EntityFrameworkCore;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    public class CustomerService : IBaseService<CustomerList>
    {
        private readonly TestDbContext _ctx;

        public CustomerService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<CustomerList> GetList(int page)
        {
            const int pageSize = 10;
            if (page == 0) page = 1;
            var totalCount = _ctx.Products.Count();
            var hasNext = (page * pageSize) < totalCount;
            var customers = await _ctx.Customers.Skip(pageSize * (page - 1)).Take(pageSize).ToListAsync();
            var customersList = new CustomerList { Items = customers , TotalCount=totalCount,HasNext=hasNext};
            return customersList;
        }

        public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
        {
            if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

            if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

            //Business Rule: Non registered Customers cannot purchase
            var customer = await _ctx.Customers.FindAsync(customerId);
            if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");

            //Business Rule: A customer can purchase only a single time per month
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var ordersInThisMonth = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any(w => w.OrderDate >= baseDate));
            if (ordersInThisMonth > 1)
                return false;

            //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
            var haveBoughtBefore = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
            if (haveBoughtBefore == 0 && purchaseValue > 100)
                return false;

            return true;
        }
    }
}
