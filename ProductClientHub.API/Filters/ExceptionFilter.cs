using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ProductClientHub.Exceptions.ExceptionsBase;
using ProductsClientHub.Communication.Responses;

namespace ProductClientHub.API.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is ProductClientHubException productClientException)
        {
            context.HttpContext.Response.StatusCode = (int)productClientException.GetHttpStatusCode();
            context.Result = new ObjectResult(new ResponseErrorMessagesJson(productClientException.GetErrors()));
        }
        else
        {
            ThrowUnknowError(context);
        }
    }

    private void ThrowUnknowError(ExceptionContext context)
    {
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(new ResponseErrorMessagesJson("ERRO DESCONHECIDO"));
    }
}