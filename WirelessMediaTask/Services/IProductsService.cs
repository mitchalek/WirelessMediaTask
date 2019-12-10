using System.Collections.Generic;
using WirelessMediaTask.Models;

namespace WirelessMediaTask.Services
{
    public interface IProductsService
    {
        public IEnumerable<Product> GetProducts();
        public Product GetProduct(int id);
        public void AddProduct(Product product);
        public void RemoveProduct(int id);

        public IEnumerable<Category> GetCategories();
        public Category GetCategory(int id);
        public void AddCategory(Category category);
        public void RemoveCategory(int id);

        public IEnumerable<Maker> GetMakers();
        public Maker GetMaker(int id);
        public void AddMaker(Maker maker);
        public void RemoveMaker(int id);

        public IEnumerable<Supplier> GetSuppliers();
        public Supplier GetSupplier(int id);
        public void AddSupplier(Supplier supplier);
        public void RemoveSupplier(int id);
    }
}
