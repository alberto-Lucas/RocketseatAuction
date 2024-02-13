using System.ComponentModel.DataAnnotations.Schema;

namespace RocketseatAuction.API.Entities
{
    //Vincula a classe a tabela no banco de dados
    //Neste caso como não havera manipulacao dos registro da tabela Items
    //nao foi configurado o DbSet
    //Por isso é preciso realizar o vincula da classe com a tabela usando a tag abaixo
    [Table("Items")] 
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public int Condition { get; set; }
        public decimal BasePrice { get; set; }
        public int AuctionId { get; set; }
    }
}
