using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using RocketseatAuction.API.Repositories;

namespace RocketseatAuction.API.Filters
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        //Email: cristiano@cristiano.com
        //Base64: Y3Jpc3RpYW5vQGNyaXN0aWFuby5jb20=
        //Exemplo de Bearer Token
        //"Bearer Y3Jpc3RpYW5vQGNyaXN0aWFuby5jb20="

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Recebo o Autenticação da Requisição
            var token = TokenOnRequest(context.HttpContext);

            //Conecto com o banco de dados
            var repository = new RocketseatAuctionDbContext();

            //Decodifico o token Base64 para UTF8
            var email = FromBase64String(token);

            //Consulto se existe o email na tabela usuário do banco de dados
            var exist = repository.Users.Any(user => user.Email.Equals(email));
        }

        private string TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();


            //Validar se autenticação não está vazia
            if (!string.IsNullOrEmpty(authentication))
            {
                throw new Exception("Token is missing.");
            }

            //Remover o "Bearer " da string do Bearer Token
            //.Length retorna quantidade de caracteres
            //.. retornar o restante da string após remover "Bearer "
            //.. esquerda pega da posição escolhida para tras
            //.. direirto pega da posição escolhida para frente
            return authentication["Bearer ".Length..];
        }

        private string  FromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);

            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
