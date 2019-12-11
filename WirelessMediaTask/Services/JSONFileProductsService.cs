using System.Collections.Generic;
using System.Linq;
using WirelessMediaTask.Models;

namespace WirelessMediaTask.Services
{
    public class JSONFileProductsService : IProductsService
    {
        private readonly ProductsJSONFileContext _context;

        public JSONFileProductsService(ProductsJSONFileContext context)
        {
            _context = context;
        }
        #region Product
        public IEnumerable<Product> GetProducts()
        {
            return _context.Model.Products;
        }
        public Product GetProduct(int id)
        {
            return _context.Model.Products.FirstOrDefault(p => p.ProductId == id);
        }
        public void AddProduct(Product product)
        {
            // Id of 0 means new.
            if (product.ProductId == 0)
            {
                // Get next unique Id.
                int newId = 1;
                if (_context.Model.Products.Count > 0)
                {
                    newId = _context.Model.Products.Max(p => p.ProductId) + 1;
                }
                product.ProductId = newId;
                _context.Model.Products.Add(product);
                _context.SaveChanges();
            }
            // Existing.
            else
            {
                // Find index of existing item and update reference.
                for (int i = 0; i < _context.Model.Products.Count; i++)
                {
                    if (_context.Model.Products[i].ProductId == product.ProductId)
                    {
                        _context.Model.Products[i] = product;
                        _context.SaveChanges();
                        break;
                    }
                }
            }
        }
        public void RemoveProduct(int id)
        {
            var product = _context.Model.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _context.Model.Products.Remove(product);
                _context.SaveChanges();
            }
        }
        #endregion
        #region Category
        public IEnumerable<Category> GetCategories()
        {
            return _context.Model.Categories;
        }
        public Category GetCategory(int id)
        {
            return _context.Model.Categories.FirstOrDefault(c => c.CategoryId == id);
        }
        public void AddCategory(Category category)
        {
            if (category.CategoryId == 0)
            {
                int newId = 1;
                if (_context.Model.Categories.Count > 0)
                {
                    newId = _context.Model.Categories.Max(c => c.CategoryId) + 1;
                }
                category.CategoryId = newId;
                _context.Model.Categories.Add(category);
                _context.SaveChanges();
            }
            else
            {
                for (int i = 0; i < _context.Model.Categories.Count; i++)
                {
                    if (_context.Model.Categories[i].CategoryId == category.CategoryId)
                    {
                        _context.Model.Categories[i] = category;
                        _context.SaveChanges();
                        break;
                    }
                }
            }
        }
        public void RemoveCategory(int id)
        {
            var category = _context.Model.Categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                _context.Model.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
        #endregion
        #region Maker
        public IEnumerable<Maker> GetMakers()
        {
            return _context.Model.Makers;
        }
        public Maker GetMaker(int id)
        {
            return _context.Model.Makers.FirstOrDefault(m => m.MakerId == id);
        }
        public void AddMaker(Maker maker)
        {
            if (maker.MakerId == 0)
            {
                int newId = 1;
                if (_context.Model.Makers.Count > 0)
                {
                    newId = _context.Model.Makers.Max(m => m.MakerId) + 1;
                }
                maker.MakerId = newId;
                _context.Model.Makers.Add(maker);
                _context.SaveChanges();
            }
            else
            {
                for (int i = 0; i < _context.Model.Makers.Count; i++)
                {
                    if (_context.Model.Makers[i].MakerId == maker.MakerId)
                    {
                        _context.Model.Makers[i] = maker;
                        _context.SaveChanges();
                        break;
                    }
                }
            }
        }
        public void RemoveMaker(int id)
        {
            var maker = _context.Model.Makers.FirstOrDefault(m => m.MakerId == id);
            if (maker != null)
            {
                _context.Model.Makers.Remove(maker);
                _context.SaveChanges();
            }
        }
        #endregion
        #region Supplier
        public IEnumerable<Supplier> GetSuppliers()
        {
            return _context.Model.Suppliers;
        }
        public Supplier GetSupplier(int id)
        {
            return _context.Model.Suppliers.FirstOrDefault(s => s.SupplierId == id);
        }
        public void AddSupplier(Supplier supplier)
        {
            if (supplier.SupplierId == 0)
            {
                int newId = 1;
                if (_context.Model.Suppliers.Count > 0)
                {
                    newId = _context.Model.Suppliers.Max(s => s.SupplierId) + 1;
                }
                supplier.SupplierId = newId;
                _context.Model.Suppliers.Add(supplier);
                _context.SaveChanges();
            }
            else
            {
                for (int i = 0; i < _context.Model.Suppliers.Count; i++)
                {
                    if (_context.Model.Suppliers[i].SupplierId == supplier.SupplierId)
                    {
                        _context.Model.Suppliers[i] = supplier;
                        _context.SaveChanges();
                        break;
                    }
                }
            }
        }
        public void RemoveSupplier(int id)
        {
            var supplier = _context.Model.Suppliers.FirstOrDefault(s => s.SupplierId == id);
            if (supplier != null)
            {
                _context.Model.Suppliers.Remove(supplier);
                _context.SaveChanges();
            }
        }
        #endregion
    }
}
