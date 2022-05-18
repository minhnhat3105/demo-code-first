using DemoCodeFirst.Data.ViewModels.City;
using DemoCodeFirst.Data.ViewModels.Common;

namespace DemoCodeFirst.Business.Services.CitySvc
{
    public interface ICityService
    {
        public Task<PagingResult<ViewCity>> GetAllCities(PagingRequest request);
        public Task<ViewCity> GetById(int id);
        public Task<ViewCity> Insert(CityInsertModel model);
        public Task Update(ViewCity model);
        public Task Delete(int id);
    }
}
