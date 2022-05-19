using DemoCodeFirst.Data.RequestModel;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.ViewModels.Entities.State;

namespace DemoCodeFirst.Business.Services.StateSvc
{
    public interface IStateService
    {
        public Task<PagingResult<ViewState>> GetStatesByConditions(StateRequestModel conditions);
        public Task<ViewState> Insert(StateInsertModel model);
        public Task Update(StateUpdateModel model);
        public Task Delete(int id);
    }
}
