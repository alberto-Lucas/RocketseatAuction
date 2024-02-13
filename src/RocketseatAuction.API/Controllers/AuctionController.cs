using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RocketseatAuction.API.Controllers
{
    public class AuctionController : RocketseatAuctionBaseController
    {
        //200 - OK
        //201 - Created
        //204 - NoContent
        //404 - NotFound
        //401 - Unauthorized

        [HttpGet]
        //Configura o Swagger para retornar o objeto Auction com o status 200
        //Apresenta um exemplo de JSON ao usuário
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        //Retorna um 200 porém nenhum registro encontrado
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction()
        {
            var useCase = new GetCurrentAuctionUseCase();
            var result = useCase.Execute();

            if(result is null)
                return NoContent();
            
            return Ok(result);
        }

        
    }
}
