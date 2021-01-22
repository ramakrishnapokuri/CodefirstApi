﻿using PrasadCodeFirst.Data.CommandQuery.Interfaces.Company;
using PrasadCodeFirst.Data.Models.Company;

namespace PrasadCodeFirst.Data.CommandQuery.Company
{
    public class EmployerRepository : Repository<Employer>, IEmployerRepository
    {
    }
}