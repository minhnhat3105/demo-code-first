using DemoCodeFirst.Data.EF;
using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirst.Data.Repository.StateRepo
{
    public class StateRepo : Repository<State>, IStateRepo
    {
        public StateRepo(DatabaseContext context) : base(context)
        {
        }
    }
}
