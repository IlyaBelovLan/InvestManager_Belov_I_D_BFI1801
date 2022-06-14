namespace InvestManager.FinancialData.UseCases.GetCurrentPrice
{
    using Common;
    using FluentValidation;
    using InvestManager.Common.Validators;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class GetCurrentPriceQueryValidator : AbstractValidator<GetCurrentPriceQuery>
    {
        public GetCurrentPriceQueryValidator()
        {
            this.NotEmptyRule(q => q.Symbol, ErrorMessages.EmptySymbol);
        }
    }
}