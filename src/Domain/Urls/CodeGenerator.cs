using System.Text;
using CSharpFunctionalExtensions;

namespace Domain.Urls;

public class CodeGenerator : ICodeGenerator
{
    private readonly Random _random = new();
    private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    public Result<Code> Generate()
    {
        var maxValue = Alphabet.Length;
        var result = new StringBuilder(Code.Length);
        
        for (var i = 0; i < Code.Length; i++)
        {
            var randomIndex = _random.Next(maxValue);
            result.Append(Alphabet[randomIndex]);
        }

        return Code.Create(result.ToString());
    }
}