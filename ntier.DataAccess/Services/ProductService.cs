using Microsoft.EntityFrameworkCore;
using ntier.DataAccess.Services.Interface;
using ntier.Models;
using ntire.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ntier.DataAccess.Services
{
    public class ProductService :IProductService
    {
        private readonly ApplicationDbContext _db;
        public ProductService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Product entity)
        {
            _db.Products.Add(entity);
        }

        public IEnumerable<Product> GetAll()
        {
            IEnumerable<Product> query = _db.Products;
            return query;
        }

        public Product GetFirstOrDefault(Expression<Func<Product, bool>> filter)
        {
            IQueryable<Product> query = _db.Products;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
        public void Remove(Product entity)
        {
            _db.Products.Remove(entity);
        }
        public void RemoveRange(IEnumerable<Product> entities)
        {
            _db.Products.RemoveRange(entities);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product product) 
        {
            //_db.Products.Update(category);
            //_db.SaveChanges();

            var objProduct = _db.Products.FirstOrDefault(x => x.Id == product.Id);
            if (objProduct != null)
            {
                product.Title = objProduct.Title;
                product.Description = objProduct.Description;
                product.ShortDescription = objProduct.ShortDescription;
                product.ISBN = objProduct.ISBN;
                product.Author= objProduct.Author;
                product.ListPrice = objProduct.ListPrice;
                product.Price = objProduct.Price;
                product.Price50 = objProduct.Price50;
                product.Price100 = objProduct.Price100;
                product.ImgeUrl = objProduct.ImgeUrl;
                product.ImgeTitle = objProduct.ImgeTitle;
                product.ImgeAlt = objProduct.ImgeAlt;
                product.CategoryId = objProduct.CategoryId;
                product.CoverTypeId= objProduct.CoverTypeId;
            }

        }
    }
}
