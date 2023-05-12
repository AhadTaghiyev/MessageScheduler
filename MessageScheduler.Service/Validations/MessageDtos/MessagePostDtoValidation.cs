

using FluentValidation;
using MessageScheduler.Service.Dtos.MessageDto;
using System.Text.RegularExpressions;

namespace MessageScheduler.Service.Validations.MessageDtos
{
    public class MessagePostDtoValidation : AbstractValidator<MessagePostDto>
    {
        public MessagePostDtoValidation()
        {
            RuleFor(x => x.Content).NotNull()
                .MinimumLength(1)
                    .WithMessage("The field in the context is required to have a minimum length of 1");
            RuleFor(x => x.SendAt).Custom((sendAt, context) =>
            {
                if (sendAt >= DateTime.UtcNow.AddHours(4))
                {
                    context.AddFailure("The date must be a future date.");
                }
            }).NotNull().NotEmpty();
            RuleFor(x => x.Method).NotEmpty().NotNull().Custom((method, context) =>
            {
                if (method.Trim().ToLower() != "telegram" || method.Trim().ToLower() != "email")
                {
                    context.AddFailure("The method must be either 'Telegram' or 'Gmail");
                }
            });

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Content.Trim().ToLower() == "email")
                {
                    Regex regex = new Regex("\\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}\\b\r\n");

                    if (!regex.IsMatch(x.To))
                        context.AddFailure("Please add a valid email address.");
                }
                else if (x.Content.Trim().ToLower() == "telegram")
                {
                    Regex regex=new Regex(x.To);
                    if (!regex.IsMatch(x.To))
                    {
                        context.AddFailure("Please add a valid number.");
                    }
                }
            });

        }
    }
}
