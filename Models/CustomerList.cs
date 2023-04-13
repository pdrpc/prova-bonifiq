using ProvaPub.Interfaces;

namespace ProvaPub.Models
{
    public class CustomerList : IBaseList<Customer>
	{
		public List<Customer>? Items { get; set; }
		public int TotalCount { get; set; }
		public bool HasNext { get; set; }
    }
}
