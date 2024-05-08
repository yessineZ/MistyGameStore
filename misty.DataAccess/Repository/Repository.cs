using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using misty.DataAccess.Repository.IRepository;
using MistyASP.DataAccess.Data;
namespace misty.DataAccess.Repository {
	public class Repository<T> : IRepository<T> where T : class {
		
		private readonly ApplicationDbContext _db ;
		internal DbSet<T> dbSet; 
		

		public Repository(ApplicationDbContext db) {
			_db = db; 
			this.dbSet = _db.Set<T>();
			_db.Games.Include(u => u.Category).Include(u => u.CategoryId); 
			//_db.Categories === dbSet
			 
		}
		public void Add(T entity) {
			dbSet.Add(entity) ;
			
			
		}

		public T Get(System.Linq.Expressions.Expression<Func<T, bool>> filter,string? includes = null) {
			IQueryable<T> query = dbSet; 
			query = query.Where(filter);
			if (!string.IsNullOrEmpty(includes)) {
				query = query.Include(includes);
			}


            return query.FirstOrDefault();
			
			
			
			//Category categoryFromDb2 = _db.Categories.Where(u=>u.Id == id).FirstOrDefault();
		}

		public IEnumerable<T> GetAll(string? includes = null) {
			IQueryable<T> query = dbSet;
			if (!string.IsNullOrEmpty(includes)) {
                query = query.Include(includes);
            }
		
			return query.ToList(); 
		}

		public void Remove(T entity) {
			dbSet.Remove(entity);

		}

		public void RemoveRange(IEnumerable<T> entity) {
			dbSet.RemoveRange(entity); 
		}
	}
}
