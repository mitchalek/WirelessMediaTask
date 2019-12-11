using System;
using System.Text.Json;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using WirelessMediaTask.Models;
using System.Linq;

namespace WirelessMediaTask.Services
{
    public class ProductsJSONFileContext : JSONFileContext<ProductsModel>
    {
        public ProductsJSONFileContext(IWebHostEnvironment environment, IConfiguration configuration) : base(environment, configuration)
        {
            // Rebuild model references.
            foreach (var product in Model.Products)
            {
                product.Category = Model.Categories.First(c => c.CategoryId == product.CategoryId);
                product.Maker = Model.Makers.First(m => m.MakerId == product.MakerId);
                product.Supplier = Model.Suppliers.First(s => s.SupplierId == product.SupplierId);
            }
        }
    }
    public class JSONFileContext<TModel> where TModel : class, new()
    {
        public readonly string _path;
        public TModel Model { get; }
        public JSONFileContext(IWebHostEnvironment environment, IConfiguration configuration)
        {
            // Init json file path.
            string defaultFolderName = "JSON";
            string defaultFileName = "WirelessMediaTask.json";
            string defaultFilePath = Path.Combine(defaultFolderName, defaultFileName);
            try
            {
                string configPath = configuration.GetValue("FilePaths:WirelessMediaTaskJSONPath", defaultFilePath);
                string fileName = Path.GetFileName(configPath);
                if (string.IsNullOrEmpty(fileName))
                {
                    fileName = defaultFileName;
                }
                string folderName = Path.GetDirectoryName(configPath);
                if (string.IsNullOrEmpty(folderName) || Path.IsPathRooted(folderName))
                {
                    folderName = defaultFolderName;
                }
                _path = Path.Combine(environment.ContentRootPath, folderName, fileName);
            }
            catch (Exception)
            {
                _path = Path.Combine(environment.ContentRootPath, defaultFolderName, defaultFileName);
            }
            // Init model.
            try
            {
                if (File.Exists(_path))
                {
                    Model = Deserialize(File.ReadAllText(_path));
                }
            }
            catch { }
            finally
            {
                if (Model == null)
                {
                    Model = new TModel();
                }
            }
        }

        public bool SaveChanges()
        {
            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(_path));
                File.WriteAllText(_path, Serialize(Model));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string Serialize(TModel model)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(model, options);
        }
        private TModel Deserialize(string json)
        {
            return JsonSerializer.Deserialize<TModel>(json);
        }
    }
}
