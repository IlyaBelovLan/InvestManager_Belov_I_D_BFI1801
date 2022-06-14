namespace InvestManager.Users.UseCases.Users.LogIn
{
    using Common.Validators;
    using FluentValidation;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class LogInQueryValidator : AbstractValidator<LogInQuery>
    {
        public LogInQueryValidator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
            
            RuleFor(q => q.Email)
                .EmailAddress()
                .WithMessage("Неверный формат адреса электронной почты!");

            this.NotEmptyRule(q => q.PasswordHash, "Не задан хэш пароля!");
        }
    }
}