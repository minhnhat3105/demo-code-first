using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.CountryRepo;
using DemoCodeFirst.Data.RequestModel;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.ViewModels.Country;
using DemoCodeFirst.Data.ViewModels.Entities.Country;

namespace DemoCodeFirst.Business.Services.CountrySvc
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _countryRepo;

        public CountryService(ICountryRepo countryRepo)
        {
            _countryRepo = countryRepo;
        }
        public async Task Delete(int id)
        {
            Country country = await _countryRepo.Get(id);
            if (country == null) throw new NullReferenceException("Not found this country");

            country.Status = false; // deleted
            await _countryRepo.Update();
        }

        public async Task<PagingResult<ViewCountry>> GetCountriesByConditions(CountryRequestModel conditions)
        {
            PagingResult<ViewCountry> countries = await _countryRepo.GetCountriesByConditions(conditions);
            if (countries == null) throw new NullReferenceException("Not found any countries");
            return countries;
        }

        public async Task<ViewCountry> Insert(string name)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("Name Null");

            bool isDuplicated = await _countryRepo.CheckDuplicatedCountry(name);
            if (isDuplicated) throw new ArgumentException("This country has existed");

            Country country = new Country()
            {
                Name = name,
                Status = true // default status
            };

            int stateId = await _countryRepo.Insert(country);
            return await _countryRepo.GetById(stateId);
        }

        public async Task Update(CountryUpdateModel model)
        {
            Country country = await _countryRepo.Get(model.Id);
            if (country == null) throw new NullReferenceException("Not found this country");

            if (!string.IsNullOrEmpty(model.Name))
            {
                bool isDuplicated = await _countryRepo.CheckDuplicatedCountry(model.Name);
                if (isDuplicated) throw new ArgumentException("This country has existed");
                country.Name = model.Name;
            } 
                
            if(model.Status.HasValue) country.Status = model.Status.Value;

            await _countryRepo.Update();
        }
    }
}
