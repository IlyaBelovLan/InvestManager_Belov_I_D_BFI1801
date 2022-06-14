namespace InvestManager.FinancialData.UseCases.SearchSymbols
{
    using Common;
    using FluentValidation;
    using InvestManager.Common.Validators;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class SearchSymbolsQueryValidator : AbstractValidator<SearchSymbolsQuery>
    {
        public SearchSymbolsQueryValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            
            this.NotEmptyRule(q => q.Symbol, ErrorMessages.EmptySymbol);

            RuleFor(q => q.OutputSize)
                .Must(size => size >= 0)
                .WithMessage("Размер результата поиска не может быть меньше нуля!");
        }
    }
}