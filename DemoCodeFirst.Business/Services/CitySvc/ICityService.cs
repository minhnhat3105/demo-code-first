using DemoCodeFirst.Data.RequestModel;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.ViewModels.Entities.City;

namespace DemoCodeFirst.Business.Services.CitySvc
{
    public interface ICityService
    {
        public Task<PagingResult<ViewCity>> GetByConditions(CityRequestModel conditions);
        public Task<ViewCity> Insert(CityInsertModel model);
        public Task Update(CityUpdateModel model);
        public Task Delete(int id);
    }
}
