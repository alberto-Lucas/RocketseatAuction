using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories
{
    public class RocketseatAuctionDbContext : DbContext
    {
        //Referencia a class Auction em Entities
        //O Nome da tabelas no banco de dados
        public  DbSet<Auction> Auctions { get; set; }
        public  DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            string baseDiretorio = AppDomain.CurrentDomain.BaseDirectory;

            // Navegue para cima no diretório para encontrar o diretório do projeto
            //Cada ".." volta uma pasta para traz ate a raiz do projeto, depois entra na pasta LocalDataBaseSQLite
            //Com isso posso baixar o repositori do GitHub em qualquer maquina que o banco de ja vai junto
            //com os registro atualizados
            string projetoDiretorio = Path.GetFullPath(Path.Combine(baseDiretorio, "..", "..", ".."));
            projetoDiretorio += "\\LocalDataBaseSQLite\\leilaoDbNLW.db";

            optionsBuilder.UseSqlite(@"Data Source="+ projetoDiretorio);
        }
    }
}
