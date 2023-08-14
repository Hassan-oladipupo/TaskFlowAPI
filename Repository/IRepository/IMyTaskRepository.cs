using TaskFlow_API.Repository.IRepository;
using TaskFlowAPI.Model;

namespace TaskFlowAPI.Repository.IRepository
{
    public interface IMyTaskRepository : IRepository<MyTask>
    {
        void Update(MyTask obj);
    }
}
