using FluentValidation.Results;

namespace Tecrian.Test.Utils;

public class ValidationErrorResponse
{
  public string Title { get; set; } = null!;
  public List<ValidationFailure> Errors { get; set; } = null!;
}
