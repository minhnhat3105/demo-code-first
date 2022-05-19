using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.GenericRepo;
using DemoCodeFirst.Data.RequestModel;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.ViewModels.Country;

namespace DemoCodeFirst.Data.Repository.CountryRepo
{
    public interface ICountryRepo : IRepository<Country>
    {
        public Task<PagingResult<ViewCountry>> GetCountriesByConditions(CountryRequestModel conditions);
        public Task<ViewCountry> GetById(int id);
        public Task<bool> CheckExistedCountry(int id);
        public Task<bool> CheckDuplicatedCountry(string name);
    }
}
