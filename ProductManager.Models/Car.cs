using System.ComponentModel.DataAnnotations;

namespace ProductManager.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Barcode { get; set; }
        [Required]
        public float Price { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
    }
}