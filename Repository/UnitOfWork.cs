using TaskFlow_API.Repository.IRepository;
using TaskFlowAPI.Data;
using TaskFlowAPI.Model;
using TaskFlowAPI.Repository.IRepository;

namespace TaskFlowAPI.Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
              _db = db;
            MyTask = new MyTaskRepository(_db);
        }

        public IMyTaskRepository MyTask { get; private set; }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
