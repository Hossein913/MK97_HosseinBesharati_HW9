using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManager.Models;
using ProductManager.Services.Interface;

namespace ProductManager.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductRepository _repository;
        public IEnumerable<Car> Cars { get; set; }

        public IndexModel(IProductRepository productRepository)
        {
            this._repository = productRepository;
        }


        public void OnGet()
        {
            Cars = _repository.GetAllProduct();
        }
    }
}
