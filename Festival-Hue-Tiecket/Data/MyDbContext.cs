using Microsoft.EntityFrameworkCore;
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
        public DbSet<Locations> locationss { get; set; }
        public DbSet<News> news { get; set; }
        public DbSet<NewsLiked> NewsLikeds { get; set; }
        public DbSet<ProgramLiked> programLikeds { get; set; }
        public DbSet<Programs> programs { get; set; }
        public DbSet<Roles> roles { get; set; }
        public DbSet<TicketCheckin> ticketCheckins { get; set; }
        public DbSet<Tickets> tickets { get; set; }
        public DbSet<TicketTypes> ticketTypes { get; set; }
        public DbSet<TypeProgram> typePrograms { get; set; }
        public DbSet<Users> users { get; set; }

    }
}
