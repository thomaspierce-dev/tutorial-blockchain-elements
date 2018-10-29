namespace BlockBoys.Tutorial.Blockchain.Infrastructure.WebApi.Validators
{
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using FluentValidation;

    public class HashRequestValidator : AbstractValidator<HashRequest>
    {
        public HashRequestValidator()
        {
            // Required Fields
            RuleFor(hr => hr.Message)
                .NotEmpty()
                .MaximumLength(1024);
        }
    }
}