using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using VSTDA_Backend.API.Models;

namespace VSTDA_Backend.API.Infrastructure
{
    public class TodoDataContext : DbContext
    {
        public TodoDataContext() : base("TodoDataContext")
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}