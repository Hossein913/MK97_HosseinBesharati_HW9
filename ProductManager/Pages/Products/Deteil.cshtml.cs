using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManager.Models;
using ProductManager.Services.Interface;

namespace ProductManager.Pages.Products
{
    public class DeteilModel : PageModel
    {
        private readonly IProductRepository _repository;
        public Car caritem { get; set; }

        public DeteilModel(IProductRepository productRepository)
        {
            this._repository = productRepository;
        }


        public IActionResult OnGet(int id)
        {
            caritem = _repository.GetProductById(id);
            if (caritem == null)
            {
                return RedirectToPage("Error");
            }
            return Page();
        }
    }
}
