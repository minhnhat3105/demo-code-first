using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.CountryRepo;
using DemoCodeFirst.Data.Repository.StateRepo;
using DemoCodeFirst.Data.RequestModel;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.ViewModels.Entities.State;

namespace DemoCodeFirst.Business.Services.StateSvc
{
    public class StateService : IStateService
    {
        private IStateRepo _stateRepo;
        private ICountryRepo _countryRepo;

        public StateService(IStateRepo stateRepo, ICountryRepo countryRepo)
        {
            _stateRepo = stateRepo;
            _countryRepo = countryRepo;
        }

        public async Task Delete(int id)
        {
            State state = await _stateRepo.Get(id);
            if (state == null) throw new NullReferenceException("Not found this state");

            state.Status = false; // deleted
            await _stateRepo.Update();
        }

        public async Task<PagingResult<ViewState>> GetStatesByConditions(StateRequestModel conditions)
        {
            PagingResult<ViewState> states = await _stateRepo.GetStatesByConditions(conditions);
            if (states == null) throw new NullReferenceException("Not found any states");
            return states;
        }

        public async Task<ViewState> Insert(StateInsertModel model)
        {
            if (string.IsNullOrEmpty(model.Name) || model.CountryId == 0) throw new ArgumentNullException("Name Null || CountryId Null");

            bool isExisted = await _countryRepo.CheckExistedCountry(model.CountryId);
            if (!isExisted) throw new ArgumentException("Not found this country");

            bool isDuplicated = await _stateRepo.CheckDuplicatedState(model.Name, model.CountryId);
            if (isDuplicated) throw new ArgumentException("This state has existed in the country");

            State state = new State()
            {
                Name = model.Name,
                CountryId = model.CountryId,
                Status = true // default status
            };

            int stateId = await _stateRepo.Insert(state);
            return await _stateRepo.GetById(stateId);
        }

        public async Task Update(StateUpdateModel model)
        {
            State state = await _stateRepo.Get(model.Id);
            if (state == null) throw new NullReferenceException("Not found this state");

            if (!string.IsNullOrEmpty(model.Name))
            {
                bool isExisted = await _stateRepo.CheckDuplicatedState(model.Name, state.CountryId);
                if (isExisted) throw new ArgumentException("This state has existed in the country");
                state.Name = model.Name;
            }
            
            if(model.Status.HasValue) state.Status = model.Status.Value;

            await _stateRepo.Update();
        }
    }
}
