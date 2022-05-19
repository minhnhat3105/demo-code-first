using DemoCodeFirst.Data.EF;
using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.GenericRepo;
using DemoCodeFirst.Data.RequestModel;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.ViewModels.Entities.State;
using Microsoft.EntityFrameworkCore;

namespace DemoCodeFirst.Data.Repository.StateRepo
{
    public class StateRepo : Repository<State>, IStateRepo
    {
        private readonly DatabaseContext _context;

        public StateRepo(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckExistedState(int id)
        {
            State state = await Get(id);
            return (state != null) ? true : false;
        }

        public async Task<PagingResult<ViewState>> GetStatesByConditions(StateRequestModel conditions)
        {
            var query = from s in _context.States
                        join c in _context.Countries on s.CountryId equals c.Id
                        select new { c, s };

            if (conditions.Id.HasValue) query = query.Where(selector => selector.s.Id.Equals(conditions.Id.Value));

            if (!string.IsNullOrEmpty(conditions.Name)) query = query.Where(selector => selector.s.Name.Contains(conditions.Name));

            if (conditions.Status.HasValue) query = query.Where(selector => selector.s.Status.Equals(conditions.Status.Value));

            if (conditions.CountryId.HasValue) query = query.Where(selector => selector.s.CountryId.Equals(conditions.CountryId.Value));

            int totalCount = query.Count();
            List<ViewState> items = await query.Skip((conditions.PageNumber - 1) * conditions.PageSize).Take(conditions.PageSize)
                                            .Select(selector => new ViewState()
                                            {
                                                Id = selector.s.Id,
                                                Name = selector.s.Name,
                                                CountryId = selector.s.Id,
                                                CountryName = selector.c.Name
                                            }).ToListAsync();

            return (totalCount > 0) ? new PagingResult<ViewState>(items, totalCount, conditions.PageNumber, conditions.PageSize) : null;
        }

        public async Task<ViewState> GetById(int id)
        {
            var query = from s in _context.States
                        join c in _context.Countries on s.CountryId equals c.Id
                        where s.Id.Equals(id)
                        select new ViewState()
                        {
                            Id = s.Id,
                            Name = s.Name,
                            CountryId = s.CountryId,
                            CountryName = c.Name
                        };

            return await query.FirstOrDefaultAsync();
        }

        public async Task<bool> CheckDuplicatedState(string name, int countryId)
        {
            State state = await (from s in _context.States
                                 where s.Name.ToLower().Equals(name.ToLower()) && s.CountryId.Equals(countryId) // && s.Status.Equals(true) // Active state
                                 select s).FirstOrDefaultAsync();

            return (state != null) ? true : false;
        }
    }
}
