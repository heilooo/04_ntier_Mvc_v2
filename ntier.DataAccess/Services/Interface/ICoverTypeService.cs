using ntier.Models;
using System.Linq.Expressions;

namespace ntier.DataAccess.Services.Interface
{
    public interface ICoverTypeService
    {
        public void Add(CoverType entity);
        public IEnumerable<CoverType> GetAll();
        public CoverType GetFirstOrDefault(Expression<Func<CoverType, bool>> filter);
        void Remove(CoverType entity);
        void RemoveRange(IEnumerable<CoverType> entities);
        void Save();
        public void Update(CoverType coverType);

    }
}
