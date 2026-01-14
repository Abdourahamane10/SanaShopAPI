using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.Common.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        #region Propriétés

        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        #endregion Propriétés

        #region Constructeurs
        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }
        #endregion Constructeurs

        #region Implémentation de IPipelineBehavior
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, 
            CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogInformation("Handling {RequestName} with data: {@Request}", requestName, request);

            var response = await next();

            _logger.LogInformation("Handled {RequestName} with response: {@Response}", requestName, response);

            return response;
        }
        #endregion Implémentation de IPipelineBehavior
    }
}
