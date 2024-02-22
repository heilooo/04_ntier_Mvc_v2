using ntier.Models;
using System.Linq.Expressions;

namespace ntier.DataAccess.Services.Interface
{
    public interface IProductService
    {
        public void Add(Product entity);
        public IEnumerable<Product> GetAll();
        public Product GetFirstOrDefault(Expression<Func<Product, bool>> filter);
        void Remove(Product entity);
        void RemoveRange(IEnumerable<Product> entities);
        void Save();
        public void Update(Product product);

    }
}
