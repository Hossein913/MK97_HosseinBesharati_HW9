using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProductManager.Models;
using ProductManager.Services.Interface;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace ProductManager.Pages.Products
{
    public class FormModel : PageModel
    {
        private readonly IProductRepository _repository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        
        [BindProperty]
        public Car caritem { get; set; }

        [BindProperty]
        public IFormFile image { get; set; }

        public FormModel(IProductRepository productRepository, IWebHostEnvironment webHostEnvironment)
        {
            this._repository = productRepository;
            this._webHostEnvironment = webHostEnvironment;
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
            if (ModelState.IsValid)
            {            

                if (image != null)
                {
                    if (caritem.Photo != null)
                    {
                        string Filepath = Path.Combine(_webHostEnvironment.WebRootPath,"images",caritem.Photo);
                        System.IO.File.Delete(Filepath);
                    }

                        caritem.Photo = Uploadimage();
                }


                caritem = _repository.Update(caritem);
            
                 return RedirectToPage("Index");
            }
            return Page();
        }

        private string Uploadimage()
        {
            string fileName = null;

            if (image != null) 
            {
                string UploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                fileName = DateTime.Now.Hour.ToString()+ DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + "_" + image.FileName;
                string Filepath = Path.Combine(UploadFolder, fileName);
                using (var filestream = new FileStream(Filepath, FileMode.Create)) 
                {
                    image.CopyTo(filestream);
                }
            }

            return fileName;
        }
    
    
    }
}
