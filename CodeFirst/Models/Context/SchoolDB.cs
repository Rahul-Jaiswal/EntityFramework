﻿using EntityFramework.CodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFramework.CodeFirst.Models.Context
{
    public class SchoolDB : System.Data.Entity.DbContext
    {
        public SchoolDB()
            : base("SchoolDB")
        {

        }

        public System.Data.Entity.DbSet<Student> Students { get; set; }
        public System.Data.Entity.DbSet Standards { get; set; }

    }
}
