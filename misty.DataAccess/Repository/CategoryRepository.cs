using misty.DataAccess.Repository.IRepository;
using misty.Models;
using MistyASP.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace misty.DataAccess.Repository
{
    public class CategoryRepository : Repository<Catergory>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
       

        public void Update(Catergory obj)
        {
            _db.catergories.Update(obj); 
        }
    }
}
