

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
                if (sendAt <= DateTime.UtcNow.AddHours(4))
                {
                    context.AddFailure("The date must be a future date. (GMT+4) Time in Azerbaijan");
                }
            }).NotNull().NotEmpty();
            RuleFor(x => x.Method).NotEmpty().NotNull().Custom((method, context) =>
            {
                if (method.Trim().ToLower() == "telegram" || method.Trim().ToLower() == "email")
                    return;
                else
                    context.AddFailure("The method must be either 'Telegram' or 'Gmail");
            });

            RuleFor(x => x).Custom((x, context) =>
            {
                if (x.Method.Trim().ToLower() == "email")
                {
                    Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

                    if (!regex.IsMatch(x.To))
                        context.AddFailure("Please add a valid email address.");
                }
                else if (x.Method.Trim().ToLower() == "telegram")
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
