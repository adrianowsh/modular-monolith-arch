using FluentValidation;

namespace Evently.Modules.Events.Application.Events.CreateEvent;

internal sealed class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must be at most 200 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(1000).WithMessage("Description must be at most 1000 characters.");

        RuleFor(x => x.Location)
            .NotEmpty().WithMessage("Location is required.")
            .MaximumLength(300).WithMessage("Location must be at most 300 characters.");

        RuleFor(x => x.StartsAtUtc)
            .LessThan(x => x.EndAtUtc).WithMessage("Start date must be before end date.")
            .GreaterThan(DateTime.UtcNow).WithMessage("Start date must be in the future.");

        RuleFor(x => x.EndAtUtc)
            .GreaterThan(x => x.StartsAtUtc).WithMessage("End date must be after start date.");
    }
}
