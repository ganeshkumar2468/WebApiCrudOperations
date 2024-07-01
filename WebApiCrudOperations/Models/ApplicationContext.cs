﻿using Microsoft.EntityFrameworkCore;
namespace WebApiCrudOperations.Models

{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)

        {
        }

        public DbSet<Data> datas { get; set; }
    }
}
