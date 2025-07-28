using Domain;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Entity_Framwork
{
    public class appDBContext : DbContext
    {
        public DbSet<Food> foods { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var config = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            var db = new SqlConnection(config.GetSection("Constr").Value);
            optionsBuilder.UseSqlServer(db);
        }
    }
}
