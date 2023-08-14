using TaskFlowAPI.Data;
using TaskFlowAPI.Model;
using TaskFlowAPI.Repository.IRepository;

namespace TaskFlowAPI.Repository
{
    public class MyTaskRepository : Repository<MyTask>, IMyTaskRepository
    {
        private readonly ApplicationDbContext _db;
        public MyTaskRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //Updating just all of the properties in Category model
        public void Update(MyTask obj)
        {

            _db.myTasks.Update(obj);
        }
    }
}
