namespace InvestManager.Tests.Notes.CreateNote
{
    using NUnit.Framework;
    using TestClient;

    public class TestValidator : TestWithAuthorization
    {
        [Test]
        public void EmptySymbolIsNotValid()
        {
            var command = new CreateNoteCommand { Symbol = "", Text = "Text" };

            Assert.That(async () => await Client.CreateNoteAsync(command).ConfigureAwait(false), Throws.Exception);
        }
        
        [Test]
        public void EmptyTextIsNotValid()
        {
            var command = new CreateNoteCommand { Symbol = "AAPL", Text = "" };

            Assert.That(async () => await Client.CreateNoteAsync(command).ConfigureAwait(false), Throws.Exception);
        }
    }
}