using System;
using System.Collections.Generic;
using System.Text;
using Infrastructure.Database.Repo.Orders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database.Context
{
    public partial class WideWorldImportersContext :DbContext
    {
        public virtual DbSet<ClientOrderRepoResponseModel> ClientOrders { get; set; }

        public WideWorldImportersContext()
        {
        }

        public WideWorldImportersContext(DbContextOptions<WideWorldImportersContext> options)
            : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
