namespace InvestManager.FinancialData.UseCases.GetPriceChart
{
    using Common;
    using FluentValidation;
    using InvestManager.Common.Validators;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class GetPriceChartQueryValidator : AbstractValidator<GetPriceChartQuery>
    {
        public GetPriceChartQueryValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            this.NotEmptyRule(q => q.Symbol, ErrorMessages.EmptySymbol);
        }
    }
}