using DemoCodeFirst.Data.EF;
using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.GenericRepo;
using DemoCodeFirst.Data.ViewModels.Entities.City;
using DemoCodeFirst.Data.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DemoCodeFirst.Data.RequestModel;

namespace DemoCodeFirst.Data.Repository.CityRepo
{
    public class CityRepo : Repository<City>, ICityRepo
    {
        private readonly DatabaseContext _context;
        public CityRepo(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckDuplicatedName(string name, int stateId)
        {
            City city = await (from c in _context.Cities
                               where c.Name.ToLower().Equals(name.ToLower()) && c.StateId.Equals(stateId) // && c.Status.Equals(true) // active city
                               select c).FirstOrDefaultAsync();

            return (city != null) ? true : false;
        }

        public async Task<PagingResult<ViewCity>> GetByConditions(CityRequestModel conditions)
        {
            var query = from c in _context.Cities
                        join s in _context.States on c.StateId equals s.Id
                        select new { c, s };

            if (conditions.Id.HasValue) query = query.Where(selector => selector.c.Id.Equals(conditions.Id));

            if (conditions.StateId.HasValue) query = query.Where(selector => selector.c.StateId.Equals(conditions.StateId));

            if (!string.IsNullOrEmpty(conditions.Name)) query = query.Where(selector => selector.c.Name.Contains(conditions.Name));

            if (conditions.Status.HasValue) query = query.Where(selector => selector.c.Status.Equals(conditions.Status));

            int totalCount = query.Count();
            List<ViewCity> items = await query.Skip((conditions.PageNumber - 1) * conditions.PageSize).Take(conditions.PageSize)
                                        .Select(selector => new ViewCity()
                                        {
                                            Id = selector.c.Id,
                                            Name = selector.c.Name,
                                            StateId = selector.c.StateId,
                                            StateName = selector.s.Name
                                        }).ToListAsync();

            return (items.Count() > 0) ? new PagingResult<ViewCity>(items, totalCount, conditions.PageNumber, conditions.PageSize) : null;
        }

        public async Task<ViewCity> GetById(int id)
        {
            var query = from c in _context.Cities
                        join s in _context.States on c.StateId equals s.Id
                        where c.Id.Equals(id)
                        select new { c, s };

            return await query.Select(selector => new ViewCity()
            {
                Id = selector.c.Id,
                StateId = selector.c.StateId,
                Name = selector.c.Name,
                StateName = selector.s.Name
            }).FirstOrDefaultAsync();
        }
    }
}
