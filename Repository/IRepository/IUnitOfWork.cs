using TaskFlowAPI.Repository.IRepository;

namespace TaskFlow_API.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IMyTaskRepository MyTask {  get; }
        void Save();
    }
}
