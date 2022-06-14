namespace InvestManager.WebApi.Infrastructure.RequestValidator
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR.Pipeline;

    public class RequestValidator<TRequest> : IRequestPreProcessor<TRequest>
    {
        private readonly IValidator<TRequest> _validator;

        public RequestValidator(IValidator<TRequest> validator = null) => _validator = validator;

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            if (_validator == null)
                return;

            var validationResult = await _validator.ValidateAsync(request, cancellationToken).ConfigureAwait(false);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors.First().ErrorMessage);
        }
    }
}