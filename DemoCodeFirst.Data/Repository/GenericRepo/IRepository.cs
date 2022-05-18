using DemoCodeFirst.Data.ViewModels.Common;

namespace DemoCodeFirst.Data.Repository.GenericRepo
{
    public interface IRepository<T> where T : class
    {
        public Task<PagingResult<T>> GetAll(PagingRequest request);
        public Task<T> Get(int id);
        public Task<int> Insert(T entity);
        public Task Update();
    }
}
