using FluentValidation;
using MediatR;
using SanaShop.Applications.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanaShop.Applications.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        #region Attributs

        private readonly IEnumerable<IValidator<TRequest>> _validators;

        #endregion Attributs

        #region Constructeurs
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }
        #endregion Constructeurs

        #region Implémentation de IPipelineBehavior
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var failures = _validators
                    .Select(v => v.Validate(context))
                    .SelectMany(result => result.Errors)
                    .Where(f => f != null)
                    .ToList();

                if (failures.Count != 0)
                {
                    string sValidationMessage = string.Join("; ", failures.Select(f => f.ErrorMessage));
                    throw CustomException.Format(
                        new Exception(sValidationMessage),
                        400,
                        CustomErrorEnum.CUSTOM_400  
                    );
                }
            }

            return await next();
        }
        #endregion Implémentation de IPipelineBehavior
    }
}
