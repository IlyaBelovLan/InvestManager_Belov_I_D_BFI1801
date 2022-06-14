namespace InvestManager.Users.UseCases.Users.RegisterUser
{
    using Common.Validators;
    using Database.Context;
    using FluentValidation;
    using JetBrains.Annotations;
    using Microsoft.EntityFrameworkCore;

    [UsedImplicitly]
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator(DatabaseContext context)
        {
            RuleLevelCascadeMode = CascadeMode.Stop;

            RuleFor(c => c.Email)
                .CustomAsync(async (email, validationContext, cancellationToken) =>
                {
                    var userWithEmailFromCommand = await context
                        .Users.FirstOrDefaultAsync(f => f.Email == email).ConfigureAwait(false);

                    if (userWithEmailFromCommand != null)
                        validationContext.AddFailure("Заданный адрес электронной почты уже занят!");
                });
                
            RuleFor(c => c.Email)
                .EmailAddress()
                .WithMessage("Неверный формат адреса электронной почты!");

            this.NotEmptyRule(c => c.UserName, "Не задано имя пользователя!");

            this.NotEmptyRule(c => c.PasswordHash, "Не задан хэш пароля!");
        }
    }
}