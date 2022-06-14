namespace InvestManager.TwelveData.Client.Json
{
    using System.Linq;
    using System.Text.Json;

    public class SnakeCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name)
        {
            var firstSymbol = char.ToLower(name.First()).ToString();
            var afterFirstSymbols = string.Concat(name.Substring(1).Select(s => char.IsUpper(s) ? $"_{s}" : s.ToString())).ToLower();
            return firstSymbol + afterFirstSymbols;
        }
    }
}