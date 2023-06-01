using Microsoft.EntityFrameworkCore;
using Festival_Hue_Tiecket.Modelsss;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Festival_Hue_Tiecket.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options): base(options) { }


        public DbSet<HelpsMenu> HelpsMenus { get; set; }
        public DbSet<LocationLiked> LocationLikeds { get; set; }
        public DbSet<Locations> Locationss { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsLiked> NewsLikeds { get; set; }
        public DbSet<ProgramLiked> ProgramLikeds { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<RolesModels> Roles { get; set; }
        public DbSet<TicketCheckin> TicketCheckins { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<TicketTypes> TicketTypes { get; set; }
        public DbSet<TypeProgram> TypePrograms { get; set; }
        public DbSet<Users> Users { get; set; }

    }
}
