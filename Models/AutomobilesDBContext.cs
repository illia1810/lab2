using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Cars.Models
{
    public class AutomobilesDBContext : DbContext
    {
        public virtual DbSet<BodyType> BodyType { get; set; }
        public virtual DbSet<Engine> Engine { get; set; }

        public virtual DbSet<ModelCar> ModelCar { get; set; }

        public virtual DbSet<ModelCarYear> ModelCarYear { get; set; }

        public virtual DbSet<PriceCategory> PriceCategory { get; set; }

        public virtual DbSet<YearOfIssue> YearOfIssue { get; set; }
        public AutomobilesDBContext(DbContextOptions<AutomobilesDBContext> options)

    : base(options)

        {
            Database.EnsureCreated();
        }
    }
}
