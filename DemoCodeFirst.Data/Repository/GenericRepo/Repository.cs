using DemoCodeFirst.Data.EF;
using DemoCodeFirst.Data.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace DemoCodeFirst.Data.Repository.GenericRepo
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DatabaseContext _context;
        private DbSet<T> _entities;

        public Repository(DatabaseContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task<PagingResult<T>> GetAll(PagingRequest request)
        {
            List<T> items = await _entities.Skip((request.PageNumber - 1) * request.PageSize).Take(request.PageSize).ToListAsync();
            return (items.Count() > 0) ? new PagingResult<T>(items, _entities.Count(), request.PageNumber, request.PageSize) : null;
        }

        public async Task<T> Get(int id)
        {
            return await _entities.FirstOrDefaultAsync(param => param.Equals(id));
        }

        public async Task<int> Insert(T entity)
        {
            await _entities.AddAsync(entity);
            await Update();
            return (int) entity.GetType().GetProperty("Id").GetValue(entity);
        }

        public async Task Update()
        {
            await _context.SaveChangesAsync();
        }
    }
}
