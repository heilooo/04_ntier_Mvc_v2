using ntier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ntier.DataAccess.Services.Interface
{
    public interface ICategoryService
    {
        public void Add(Category entity);
        public IEnumerable<Category> GetAll();
        public Category GetFirstOrDefault(Expression<Func<Category,bool>>filter);
        void Remove(Category entity);
        void RemoveRange(IEnumerable<Category> entities);
        public void Update(Category category);
    }
}
