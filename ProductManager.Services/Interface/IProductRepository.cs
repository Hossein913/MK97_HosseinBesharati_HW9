using ProductManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ProductManager.Services.Interface
{
    public  interface IProductRepository
    {
        IEnumerable<Car> GetAllProduct();
        Car GetProductById(int id);

        Car Update(Car car);

        Car Delete(int id);
        void create(Car car);
    }
}
