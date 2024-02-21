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
    public class CoverTypeService: ICoverTypeService
    {
        private readonly ApplicationDbContext _db;
        public CoverTypeService(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(CoverType entity)
        {
            _db.CoverTypes.Add(entity);
        }

        public IEnumerable<CoverType>GetAll()
        {
            IEnumerable<CoverType> query = _db.CoverTypes;
            return query;
        }

        public CoverType GetFirstOrDefault(Expression<Func<CoverType,bool>> filter)
        {
            IQueryable<CoverType> query = _db.CoverTypes;
            query = query.Where(filter);
            return query.FirstOrDefault();
        }
        public void Remove(CoverType entity)
        {
            _db.CoverTypes.Remove(entity);
        }
        public void RemoveRange(IEnumerable<CoverType> entities)
        {
            _db.CoverTypes.RemoveRange(entities);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(CoverType CoverType) 
        {
            _db.CoverTypes.Update(CoverType);
        }



    }
}
