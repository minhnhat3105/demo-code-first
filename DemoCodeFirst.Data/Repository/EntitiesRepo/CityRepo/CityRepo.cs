using DemoCodeFirst.Data.EF;
using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.GenericRepo;
using DemoCodeFirst.Data.ViewModels.City;
using DemoCodeFirst.Data.ViewModels.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DemoCodeFirst.Data.Repository.CityRepo
{
    public class CityRepo : Repository<City>, ICityRepo
    {
        private readonly DatabaseContext _context;
        public CityRepo(DatabaseContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagingResult<ViewCity>> GetAllCities(PagingRequest request)
        {
            var query = from c in _context.Cities
                        select c;

            int totalCount = query.Count();
            List<ViewCity> items = await query.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize)
                                            .Select(city => new ViewCity()
                                            {
                                                Id = city.Id,
                                                Name = city.Name,
                                                StateId = city.StateId
                                            }).ToListAsync();

            return (totalCount > 0) ? new PagingResult<ViewCity>(items, totalCount, request.PageNumber, request.PageSize) : null;
        }
    }
}
