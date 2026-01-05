using DirectoryService.Shared.Errors;
using FluentValidation.Results;

namespace DirectoryService.Application.Extensions;

public static class ValidationExtensions
{
    public static Failure ToErrors(this ValidationResult validationResult)
    {
        return validationResult.Errors.Select(e => Error.Validation(e.ErrorCode, e.ErrorMessage, e.PropertyName)).ToArray();
    }
}