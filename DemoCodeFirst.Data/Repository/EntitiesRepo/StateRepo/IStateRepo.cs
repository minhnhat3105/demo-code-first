using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.GenericRepo;
using DemoCodeFirst.Data.RequestModel;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.ViewModels.Entities.State;

namespace DemoCodeFirst.Data.Repository.StateRepo
{
    public interface IStateRepo : IRepository<State>
    {
        public Task<PagingResult<ViewState>> GetStatesByConditions(StateRequestModel conditions);
        public Task<ViewState> GetById(int id);
        public Task<bool> CheckExistedState(int id);
        public Task<bool> CheckDuplicatedState(string name, int countryId);
    }
}
