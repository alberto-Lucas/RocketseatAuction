using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories
{
    public class RocketseatAuctionDbContext : DbContext
    {
        //Referencia a class Auction em Entities
        //O Nome da tabelas no banco de dados
        public  DbSet<Auction> Auctions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\SQLite\leilaoDbNLW.db");
        }
    }
}
