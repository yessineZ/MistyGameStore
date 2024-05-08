using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace misty.DataAccess.Repository.IRepository {
	public  interface IRepository<T> where T : class {
		IEnumerable<T> GetAll(string? includes = null);
		T Get(Expression<Func<T, bool>> filter, string? includes = null);
		void Add(T entity);
		void Remove(T entity); 
		void RemoveRange(IEnumerable<T> entity);
	
	
	}
}
