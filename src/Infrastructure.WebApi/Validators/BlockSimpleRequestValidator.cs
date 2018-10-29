namespace BlockBoys.Tutorial.Blockchain.Infrastructure.WebApi.Validators
{
    using BlockBoys.Tutorial.Blockchain.Core.Application.Messages;
    using FluentValidation;

    public class BlockSimpleRequestValidator : AbstractValidator<BlockSimpleRequest>
    {
        public BlockSimpleRequestValidator()
        {
            // Required Fields
            RuleFor(bsr => bsr.BlockData)
                .NotEmpty()
                .MaximumLength(1024);
            
            RuleFor(bsr => bsr.BlockNumber)
                .GreaterThan(0)
                .LessThanOrEqualTo(int.MaxValue);
            
            RuleFor(bsr => bsr.Nonce)
                .LessThanOrEqualTo(ulong.MaxValue);
        }
    }
}