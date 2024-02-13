using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Communication.Requests;
using RocketseatAuction.API.Filters;



namespace RocketseatAuction.API.Controllers
{
    //Autenticando de requisição 
    [ServiceFilter(typeof(AuthenticationUserAttribute))]
    //Neste ponto autentica todas as requisições abaixo

    public class OfferController : RocketseatAuctionBaseController
    {
        [HttpPost]
        //Vincular o parametro do método ao parametro da rota
        [Route("{itemId}")]
        //Autenticando de requisição 
        //[ServiceFilter(typeof(AuthenticationUserAttribute))]
        //Neste ponto autentica apenas a requisição abaixo

        //Recebe informações em formato JSON no Body da requisição
        public IActionResult CreateOffer([FromRoute]int itemId, [FromBody]ResquestCreateOfferJson request)
        {
            return Created();
        }
    }
}
