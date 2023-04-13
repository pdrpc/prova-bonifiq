using Microsoft.AspNetCore.Mvc;
using ProvaPub.Interfaces;
using ProvaPub.Models;
using ProvaPub.Repository;

namespace ProvaPub.Controllers
{

    [ApiController]
	[Route("[controller]")]
	public class Parte2Controller :  ControllerBase
	{
		/// <summary>
		/// Precisamos fazer algumas alterações:
		/// 1 - Não importa qual page é informada, sempre são retornados os mesmos resultados. Faça a correção.
		/// 2 - Altere os códigos abaixo para evitar o uso de "new", como em "new ProductService()". Utilize a Injeção de Dependência para resolver esse problema
		/// 3 - Dê uma olhada nos arquivos /Models/CustomerList e /Models/ProductList. Veja que há uma estrutura que se repete. 
		/// Como você faria pra criar uma estrutura melhor, com menos repetição de código? E quanto ao CustomerService/ProductService. Você acha que seria possível evitar a repetição de código?
		/// 
		/// </summary>
		TestDbContext _ctx;
        IBaseService<CustomerList> _cBaseService;
        IBaseService<ProductList> _pBaseService;
		public Parte2Controller(TestDbContext ctx, IBaseService<CustomerList> cBaseService, IBaseService<ProductList> pBaseService)
		{
			_ctx = ctx;
            _cBaseService = cBaseService;
			_pBaseService = pBaseService;
		}

        [HttpGet("products")]
        public async Task<ProductList> ListProducts(int page)
        {
			var products = await _pBaseService.GetList(page);
			return products;
        }

        [HttpGet("customers")]
        public async Task<CustomerList> ListCustomers(int page)
        {
            var customers = await _cBaseService.GetList(page);
            return customers;
        }
    }
}
