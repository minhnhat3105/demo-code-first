using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.GenericRepo;
using DemoCodeFirst.Data.ViewModels.City;
using DemoCodeFirst.Data.ViewModels.Common;

namespace DemoCodeFirst.Data.Repository.CityRepo
{
    public interface ICityRepo : IRepository<City>
    {
        public Task<PagingResult<ViewCity>> GetAllCities(PagingRequest request);
    }
}
