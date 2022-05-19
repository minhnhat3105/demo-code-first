using DemoCodeFirst.Data.EF;
using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.GenericRepo;
using DemoCodeFirst.Data.RequestModel;
using DemoCodeFirst.Data.ViewModels.Common;
using DemoCodeFirst.Data.ViewModels.Country;
using Microsoft.EntityFrameworkCore;

namespace DemoCodeFirst.Data.Repository.CountryRepo
{
    public class CountryRepo : Repository<Country>, ICountryRepo
    {
        private readonly DatabaseContext _context;

        public CountryRepo(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> CheckDuplicatedCountry(string name)
        {
            Country country = await (from c in _context.Countries
                                     where c.Name.ToLower().Equals(name.ToLower())
                                     select c).FirstOrDefaultAsync();

            return (country != null) ? true : false;
        }

        public async Task<bool> CheckExistedCountry(int id)
        {
            Country country = await Get(id);
            return (country != null) ? true : false;
        }

        public async Task<PagingResult<ViewCountry>> GetCountriesByConditions(CountryRequestModel conditions)
        {
            var query = from c in _context.Countries
                        select c;

            if (conditions.Id.HasValue) query = query.Where(selector => selector.Id.Equals(conditions.Id));

            if (!string.IsNullOrEmpty(conditions.Name)) query = query.Where(selector => selector.Name.Contains(conditions.Name));

            if (conditions.Status.HasValue) query = query.Where(selector => selector.Status.Equals(conditions.Status));

            int totalCount = query.Count();
            List<ViewCountry> items = await query.Skip((conditions.PageNumber - 1) * conditions.PageSize).Take(conditions.PageSize)
                                            .Select(selector => new ViewCountry()
                                            {
                                                Id = selector.Id,
                                                Name = selector.Name,
                                            }).ToListAsync();

            return (totalCount > 0) ? new PagingResult<ViewCountry>(items, totalCount, conditions.PageNumber, conditions.PageSize) : null;
        }

        public async Task<ViewCountry> GetById(int id)
        {
            var query = from c in _context.Countries
                        where c.Id.Equals(id)
                        select new ViewCountry()
                        {
                            Id = c.Id,
                            Name = c.Name,
                        };

            return await query.FirstOrDefaultAsync();
        }
    }
}
