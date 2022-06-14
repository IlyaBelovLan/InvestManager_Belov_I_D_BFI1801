namespace InvestManager.FinancialData.UseCases.GetStocksList
{
    using FluentValidation;
    using InvestManager.Common.Validators;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class GetStocksListQueryValidator : AbstractValidator<GetStocksListQuery>
    {
        public GetStocksListQueryValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            
            this.NotEmptyRule(q => q.Exchange, "Название биржи не может быть пустым!");
        }
    }
}