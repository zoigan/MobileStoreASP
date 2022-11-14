using MediatR;
using FluentValidation;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MobileStore.Common.Behaviors
{
    public class ValidationBehavior<TRequest, TRespons>
        :IPipelineBehavior<TRequest, TRespons> where TRequest : IRequest<TRespons>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) 
            => _validators=validators;
        
        public Task<TRespons> Handle(TRequest request, 
            RequestHandlerDelegate<TRespons> next, 
            CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);
            var failure = _validators
                .Select(v => v.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .ToList();
            if (failure.Count != 0)
            {
                throw new ValidationException(failure);
            }

            return next();
        }
    }
}
