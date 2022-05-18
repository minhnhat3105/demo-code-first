using DemoCodeFirst.Data.EF;
using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.GenericRepo;

namespace DemoCodeFirst.Data.Repository.CountryRepo
{
    public class CountryRepo : Repository<Country>, ICountryRepo
    {
        public CountryRepo(DatabaseContext context) : base(context)
        {
        }
    }
}
