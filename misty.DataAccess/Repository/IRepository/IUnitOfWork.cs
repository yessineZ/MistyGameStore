using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace misty.DataAccess.Repository.IRepository {
	public interface IUnitOfWork {
		ICategoryRepository CategoryRepository { get;  }
		IGameRepository GameRepository { get; }
		void Save();

	

	}
}
