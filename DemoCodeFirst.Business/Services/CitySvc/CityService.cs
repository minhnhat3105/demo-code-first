using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.CityRepo;
using DemoCodeFirst.Data.ViewModels.City;
using DemoCodeFirst.Data.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirst.Business.Services.CitySvc
{
    public class CityService : ICityService
    {
        private ICityRepo _cityRepo;

        public CityService(ICityRepo cityRepo)
        {
            _cityRepo = cityRepo;
        }

        public async Task Delete(int id)
        {
            City city = await _cityRepo.Get(id);
            if (city == null) throw new NullReferenceException("Not found this city");

            city.Status = false; // deleted
            await _cityRepo.Update();
        }

        public async Task<PagingResult<ViewCity>> GetAllCities(PagingRequest request)
        {
            PagingResult<ViewCity> cities = await _cityRepo.GetAllCities(request);
            if (cities == null) throw new NullReferenceException("Not found any cities");
            return cities;
        }

        public Task<ViewCity> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ViewCity> Insert(CityInsertModel model)
        {
            throw new NotImplementedException();
        }

        public Task Update(ViewCity model)
        {
            throw new NotImplementedException();
        }
    }
}
