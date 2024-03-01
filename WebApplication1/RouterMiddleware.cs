using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Routing;

namespace WebApplication1;

public class RouterMiddleware
{
    private readonly RequestDelegate next;

    public RouterMiddleware(RequestDelegate next)
        => this.next = next;

    public async Task InvokeAsync(HttpContext context, EndpointDataSource endpointSources)
    {
        // Obtém o endpoint correspondente à requisição atual
        // Obs .: O método GetEndpoint() retorna null se não houver um endpoint correspondente
        var endpoint = context?.GetEndpoint();

        var endpointEhNull = endpoint is null;

        // Verifica se o endpoint obtido é nulo e se a requisição é para a documentação do Swagger
        if ((!endpointEhNull && !endpointSources.Endpoints.Contains(endpoint)) ||
        // Verifica se o endpoint obtido não é nulo e se o tipo de conteúdo da requisição é JSON
        (!endpointEhNull && context.Request.ContentType != "application/json") ||
        // Verifica se o endpoint obtido é nulo e se a requisição não é para a documentação do Swagger
        (endpointEhNull && (context.Request.Path != "/swagger/index.html" && context.Request.Path != "/swagger/v1/swagger.json")))
        {
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsync("Erroooou!!");
            return;
        }
        await next(context);
    }
}