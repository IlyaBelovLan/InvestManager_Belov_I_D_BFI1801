namespace InvestManager.Tests.Notes
{
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using NUnit.Framework;
    using TestClient;

    public class TestUseCase : TestWithAuthorization
    {
        [Test]
        public async Task CreateAndGetNote()
        {
            var testText = Helper.CreateRandomString(32);
            var createNoteCommand = new CreateNoteCommand { Symbol = "AAPL", Text = testText };
            await Client.CreateNoteAsync(createNoteCommand).ConfigureAwait(false);

            var getNotesQuery = new GetNotesQuery { Symbol = "" };

            var getNotesResponse = await Client.GetNotesAsync(getNotesQuery).ConfigureAwait(false);

            var newNote = getNotesResponse.Notes.SingleOrDefault(n => n.Text == testText);
            
            Assert.NotNull(newNote);
        }
    }
}