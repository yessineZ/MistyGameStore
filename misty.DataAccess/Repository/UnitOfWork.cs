using misty.DataAccess.Repository.IRepository;
using MistyASP.DataAccess.Data;

namespace misty.DataAccess.Repository {
    public class UnitOfWork : IUnitOfWork {
        private readonly ApplicationDbContext _db;

        public ICategoryRepository CategoryRepository { get; private set; }
        public IGameRepository GameRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext db) {
            _db = db;
            CategoryRepository = new CategoryRepository(_db);
            GameRepository = new GameRepository(_db);
        }
        

        public void Save() {
            _db.SaveChanges();
        }
    }
}
