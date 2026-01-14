using SanaShop.API.DTOs;
using SanaShop.Applications.Exceptions;
using System.Text.Json;

namespace SanaShop.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        #region propriétés

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;

        #endregion propriétés

        #region constructeurs
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger, 
            IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        #endregion constructeurs

        #region méthodes publiques
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (CustomException ex)
            {
                _logger.LogWarning(
                    ex, 
                    "Erreur métier - TraceId : {TraceId} - Message : {Message}", 
                    context.TraceIdentifier,
                    ex.Message
                );

                await HandleCustomExceptionAsync(context, ex);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex, 
                    "Erreur non gérée - TraceId : {TraceId}", 
                    context.TraceIdentifier
                );

                await HandleGenericExceptionAsync(context, ex);
            }
        }
        #endregion méthodes publiques

        #region méthodes privées
        private async Task HandleCustomExceptionAsync(HttpContext context, CustomException customException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = customException.StatusCode ?? StatusCodes.Status500InternalServerError;

            ErrorDetails oErrorDetails = GetErrorDetails(context, customException);

            var options = GetJsonSerializerOptions();

            var jsonResponse = JsonSerializer.Serialize(oErrorDetails, options);
            await context.Response.WriteAsync(jsonResponse);
        }

        private async Task HandleGenericExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            ErrorDetails oErrorDetails = GetErrorDetails(context, ex);

            var options = GetJsonSerializerOptions();

            var jsonResponse = JsonSerializer.Serialize(oErrorDetails, options);

            await context.Response.WriteAsync(jsonResponse);
        }

        private ErrorDetails GetErrorDetails(HttpContext context, Exception ex)
        {
            ErrorDetails oErrorDetails = new ErrorDetails(
                StatusCode: context.Response.StatusCode,
                Message: ex is CustomException customException
                ? customException.Message
                : "Une erreur interne est survenue.",
                TraceIdentifier: context.TraceIdentifier,
                InnerException: _env.IsDevelopment() ? ex.InnerException?.Message : null,
                Source: _env.IsDevelopment() ? ex.Source : null,
                StackTrace: _env.IsDevelopment() ? ex.StackTrace : null
            );

            return oErrorDetails;
        }

        private JsonSerializerOptions GetJsonSerializerOptions()
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            return options;
        }
        #endregion méthodes privées
    }
}
