using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirelessMediaTask.Models;

namespace WirelessMediaTask.Services
{
    public class DatabaseProductsService : IProductsService
    {
        private readonly ProductsContext _context;
        public DatabaseProductsService(ProductsContext context)
        {
            _context = context;
        }
        #region Product
        public IEnumerable<Product> GetProducts()
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Maker).Include(p => p.Supplier).ToArray();
        }
        public Product GetProduct(int id)
        {
            return _context.Products.Include(p => p.Category).Include(p => p.Maker).Include(p => p.Supplier).FirstOrDefault(p => p.ProductId == id);
        }
        public void AddProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                _context.Add(product);
            }
            else
            {
                _context.Update(product);
            }
            _context.SaveChanges();
        }
        public void RemoveProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        #endregion
        #region Category
        public IEnumerable<Category> GetCategories()
        {
            return _context.Categories.ToArray();
        }
        public Category GetCategory(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryId == id);
        }
        public void AddCategory(Category category)
        {
            if (category.CategoryId == 0)
            {
                _context.Add(category);
            }
            else
            {
                _context.Update(category);
            }
            _context.SaveChanges();
        }
        public void RemoveCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        #endregion
        #region Maker
        public IEnumerable<Maker> GetMakers()
        {
            return _context.Makers.ToArray();
        }
        public Maker GetMaker(int id)
        {
            return _context.Makers.FirstOrDefault(m => m.MakerId == id);
        }
        public void AddMaker(Maker maker)
        {
            if (maker.MakerId == 0)
            {
                _context.Add(maker);
            }
            else
            {
                _context.Update(maker);
            }
            _context.SaveChanges();
        }
        public void RemoveMaker(int id)
        {
            var maker = _context.Makers.Find(id);
            if (maker != null)
            {
                _context.Makers.Remove(maker);
                _context.SaveChanges();
            }
        }
        #endregion
        #region Supplier
        public IEnumerable<Supplier> GetSuppliers()
        {
            return _context.Suppliers.ToArray();
        }
        public Supplier GetSupplier(int id)
        {
            return _context.Suppliers.FirstOrDefault(s => s.SupplierId == id);
        }
        public void AddSupplier(Supplier supplier)
        {
            if (supplier.SupplierId == 0)
            {
                _context.Add(supplier);
            }
            else
            {
                _context.Update(supplier);
            }
            _context.SaveChanges();
        }
        public void RemoveSupplier(int id)
        {
            var supplier = _context.Suppliers.Find(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
