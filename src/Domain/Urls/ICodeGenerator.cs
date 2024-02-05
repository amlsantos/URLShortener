using CSharpFunctionalExtensions;

namespace Domain.Urls;

public interface ICodeGenerator
{
    public Result<Code> Generate();
}