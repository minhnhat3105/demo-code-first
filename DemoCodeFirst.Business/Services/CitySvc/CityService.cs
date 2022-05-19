using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.CityRepo;
using DemoCodeFirst.Data.ViewModels.Entities.City;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.Repository.StateRepo;
using DemoCodeFirst.Data.RequestModel;

namespace DemoCodeFirst.Business.Services.CitySvc
{
    public class CityService : ICityService
    {
        private ICityRepo _cityRepo;
        private IStateRepo _stateRepo;

        public CityService(ICityRepo cityRepo, IStateRepo stateRepo)
        {
            _cityRepo = cityRepo;
            _stateRepo = stateRepo;
        }

        public async Task Delete(int id)
        {
            City city = await _cityRepo.Get(id);
            if (city == null) throw new NullReferenceException("Not found this city");

            city.Status = false; // deleted
            await _cityRepo.Update();
        }

        public async Task<PagingResult<ViewCity>> GetByConditions(CityRequestModel conditions)
        {
            PagingResult<ViewCity> cities = await _cityRepo.GetByConditions(conditions);
            if (cities == null) throw new NullReferenceException("Not found this city");
            return cities;
        }

        public async Task<ViewCity> Insert(CityInsertModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || model.StateId == 0) throw new ArgumentNullException("Name Null || StateId Null");

            bool isExisted = await _stateRepo.CheckExistedState(model.StateId);
            if (!isExisted) throw new ArgumentException("The State is not existed");

            bool isDuplicatedName = await _cityRepo.CheckDuplicatedName(model.Name, model.StateId);
            if (isDuplicatedName) throw new ArgumentException("The city has existed");

            City city = new City()
            {
                Name = model.Name,
                StateId = model.StateId,
                Status = true // default status
            };

            int cityId = await _cityRepo.Insert(city);
            return await _cityRepo.GetById(cityId);
        }

        public async Task Update(CityUpdateModel model)
        {
            City city = await _cityRepo.Get(model.Id);
            if (city == null) throw new NullReferenceException("Not found this city");

            if (!string.IsNullOrEmpty(model.Name))
            {
                bool isDuplicatedName = await _cityRepo.CheckDuplicatedName(model.Name, city.StateId);
                if (isDuplicatedName) throw new ArgumentException("The city in this state has existed");
                city.Name = model.Name;
            }

            if (model.Status.HasValue) city.Status = model.Status.Value;
            
            await _cityRepo.Update();
        }
    }
}
