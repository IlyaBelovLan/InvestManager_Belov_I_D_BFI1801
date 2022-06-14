namespace InvestManager.Users.UseCases.Notes.CreateNote
{
    using Common.Validators;
    using FinancialData.UseCases.Common;
    using FluentValidation;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
    {
        public CreateNoteCommandValidator()
        {
            this.NotEmptyRule(c => c.Symbol, ErrorMessages.EmptySymbol);
            this.NotEmptyRule(c => c.Text, "Текст заметки не может быть пустым!");
        }
    }
}