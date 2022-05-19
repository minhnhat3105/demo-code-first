using DemoCodeFirst.Data.RequestModel;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.ViewModels.Country;
using DemoCodeFirst.Data.ViewModels.Entities.Country;

namespace DemoCodeFirst.Business.Services.CountrySvc
{
    public interface ICountryService
    {
        public Task<PagingResult<ViewCountry>> GetCountriesByConditions(CountryRequestModel condition);
        public Task<ViewCountry> Insert(string name);
        public Task Update(CountryUpdateModel model);
        public Task Delete(int id);
    }
}
