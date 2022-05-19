using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.GenericRepo;
using DemoCodeFirst.Data.ViewModels.Entities.City;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.RequestModel;

namespace DemoCodeFirst.Data.Repository.CityRepo
{
    public interface ICityRepo : IRepository<City>
    {
        public Task<PagingResult<ViewCity>> GetByConditions(CityRequestModel conditions);
        public Task<ViewCity> GetById(int id);
        public Task<bool> CheckDuplicatedName(string name, int stateId);
    }
}
