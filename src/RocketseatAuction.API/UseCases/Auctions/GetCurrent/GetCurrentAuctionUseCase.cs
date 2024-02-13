using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent
{
    //Classe de regra de negocios
    public class GetCurrentAuctionUseCase
    {
        //Usar ? para identificar que o objeto pode ser nullo
        public Auction? Execute()
        {
            var repository = new RocketseatAuctionDbContext();
            //var today = DateTime.Now; //Retorna a data atual
            //Forçar uma data para consulta o registro na tabela
            var today = new DateTime(2024, 01, 21);

            //Carregar os itens vinculados ao Leilao
            return repository
                .Auctions
                .Include(auction => auction.Items) //Retonar o itens vinculados
                .FirstOrDefault(auction => today >= auction.Starts && today <= auction.Ends); //Filtrando para retorna o primeiro registro da data atual
        }
    }
}
