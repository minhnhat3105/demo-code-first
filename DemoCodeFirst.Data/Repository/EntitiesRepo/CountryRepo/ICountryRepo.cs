﻿using DemoCodeFirst.Data.Entities;
using DemoCodeFirst.Data.Repository.GenericRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCodeFirst.Data.Repository.CountryRepo
{
    public interface ICountryRepo : IRepository<Country>
    {

    }
}