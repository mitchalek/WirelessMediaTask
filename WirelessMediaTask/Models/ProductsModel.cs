
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WirelessMediaTask.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        [Display(Name = "Category")]
        [Required]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
        [Display(Name = "Maker")]
        [Required]
        public int MakerId { get; set; }
        [JsonIgnore]
        public Maker Maker { get; set; }
        [Display(Name = "Supplier")]
        [Required]
        public int SupplierId { get; set; }
        [JsonIgnore]
        public Supplier Supplier { get; set; }
    }
    public class Category
    {
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
    public class Maker
    {
        public int MakerId { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
    public class Supplier
    {
        public int SupplierId { get; set; }
        [Required]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }


    public class ProductsModel
    {
        public IList<Category> Categories { get; set; } = new List<Category>();
        public IList<Maker> Makers { get; set; } = new List<Maker>();
        public IList<Supplier> Suppliers { get; set; } = new List<Supplier>();
        public IList<Product> Products { get; set; } = new List<Product>();
    }
    public class ProductsContext : DbContext
    {
        public ProductsContext() : base() { }
        public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Maker> Makers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}