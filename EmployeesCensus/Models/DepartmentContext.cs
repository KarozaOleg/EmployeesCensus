﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeesCensus.Models
{
    public class DepartmentContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
    }
}