using ProductManager.Models;
using ProductManager.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProductManager.Services.Services
{
    public class ProductRepository : IProductRepository
    {
        private List<Car> _cars;
        public ProductRepository() 
        {
            _cars = new List<Car>() {
                new Car(){Id = 1, Name = "Quick", Barcode = "Q212", Price = 5334, Photo = "Quick.jpg", Description = "s type"},
                new Car(){Id = 2, Name = "Shahin", Barcode = "SP100", Price = 9500, Photo = "Shahin.jpg", Description = "G type"},
                new Car(){Id = 3, Name = "Dena", Barcode = "NX7", Price = 12110, Photo = "Dena.jpg", Description = "Automatic type with Turbo charger"},
                new Car(){Id = 4, Name = "Tara", Barcode = "IKP1", Price = 10890, Photo = "Tara.jpg", Description = "base type"}
            };
        
        }

        public void create(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            _cars.Remove(car);
        }

        public IEnumerable<Car> GetAllProduct()
        {
            return _cars;
        }

        public Car GetProductById(int id)
        {
            return _cars.FirstOrDefault(P => P.Id == id);
        }

        public Car Update(Car updatedcar)
        {
            Car car = _cars.Find(p => p.Id == updatedcar.Id);
            if (car != null)
            {
                car.Name = updatedcar.Name;
                car.Barcode = updatedcar.Barcode;
                car.Price = updatedcar.Price;
                car.Description = updatedcar.Description;

            }
            return car;

        }
    }
}
