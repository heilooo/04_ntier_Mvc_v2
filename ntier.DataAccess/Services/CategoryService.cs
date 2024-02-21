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
    public class CategoryService :ICategoryService
    {
        private readonly ApplicationDbContext _db;
        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Category entity)
        {
            _db.Categories.Add(entity);
        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> query = _db.Categories;
            return query;
        }

        public Category GetFirstOrDefault(Expression<Func<Category, bool>> filter)
        {
            IQueryable<Category> query = _db.Categories;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
        public void Remove(Category entity)
        {
            _db.Categories.Remove(entity);
        }
        public void RemoveRange(IEnumerable<Category> entities)
        {
            _db.Categories.RemoveRange(entities);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Category category) 
        {
            _db.Categories.Update(category);
        }
    }
}
