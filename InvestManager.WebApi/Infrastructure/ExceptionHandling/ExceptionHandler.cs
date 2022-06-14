namespace InvestManager.WebApi.Infrastructure.ExceptionHandling
{
    using System.Net;
    using Common.Authorization.AccessToken.Exceptions;
    using Common.Exceptions;
    using FluentValidation;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using TwelveData.Client;

    public class ExceptionHandler : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            
            context.Result = exception switch
            {
                ValidationException validationException => BadRequestResult(validationException.Message),
                TwelveDataException twelveDataException => InternalServerErrorResult("При получении данных с биржи произошла ошибка!"),
                UseCaseException useCaseException => InternalServerErrorResult(useCaseException.Message),
                UnauthorizedException unauthorizedException => UnauthorizedResult(unauthorizedException.Message),
                _ => UnknownErrorResult("Произошла неизвестна ошибка!")
            };
            
            context.ExceptionHandled = true;
            
        }

        private static JsonResult BadRequestResult(object value) => JsonResult(value, (int)HttpStatusCode.BadRequest);
        
        private static JsonResult InternalServerErrorResult(object value) => JsonResult(value, (int)HttpStatusCode.InternalServerError);
        
        private static JsonResult UnauthorizedResult(object value) => JsonResult(value, (int)HttpStatusCode.Unauthorized);
        
        private static JsonResult UnknownErrorResult(object value) => JsonResult(value, 520);

        private static JsonResult JsonResult(object value, int statusCode) => new JsonResult(value){ StatusCode = statusCode };
    }
}