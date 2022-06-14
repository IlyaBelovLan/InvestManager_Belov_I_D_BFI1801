namespace InvestManager.Common.Validators
{
    using System;
    using System.Linq.Expressions;
    using FluentValidation;

    public static class ValidatorExtension
    {
        public static IRuleBuilderOptions<TRequest, TProperty> NotEmptyRule<TRequest, TProperty>(
            this AbstractValidator<TRequest> validator,
            Expression<Func<TRequest, TProperty>> expression, 
            string errorMessage) => 
            validator.RuleFor(expression).NotEmpty().WithMessage(errorMessage);
    }
}