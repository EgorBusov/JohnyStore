using JohnyStoreData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnyStoreData.EF
{
    public class JohnyStoreContext : DbContext
    {
        public JohnyStoreContext(DbContextOptions<JohnyStoreContext> options)
        : base(options)
        {

        }

        public DbSet<Availability> Availability { get; set; }
        public DbSet<AvailabilityStatus> AvailabilityStatuses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ModelSneaker> ModelsSneakers { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<PictureSneaker> PictureSneakers { get;set; }
        public DbSet<Style> Styles { get; set; }
    }
}
