using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManager.Models;
using ProductManager.Services.Interface;

namespace ProductManager.Pages.Products
{
    public class DeleteModel : PageModel
    {
        private readonly IProductRepository _repository;
        [BindProperty]
        public Car caritem { get; set; }

        public DeleteModel(IProductRepository productRepository)
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

        public IActionResult OnPost()
        {
            caritem = _repository.Delete(caritem.Id);

            if (caritem == null)
            {
                return RedirectToPage("Error");
            }
            return RedirectToPage("Index");

        }
    }
}
