using Common.Application;
using Common.Application.Validation;
using FluentValidation;
using Shop.Domain.UserAgg;
using Shop.Domain.UserAgg.Enums;
using Shop.Domain.UserAgg.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Users.ChargeWallet
{
    public class ChargeUserWalletCommand : IBaseCommand
    {
        public long UserId { get; private set; }
        public int Price { get; private set; }
        public string Description { get; private set; }
        public bool IsFinally { get; private set; }
        public WalletType Type { get; private set; }

        public ChargeUserWalletCommand(long userId, int price, string description, bool isFinally
            , WalletType type)
        {
            UserId = userId;
            Price = price;
            Description = description;
            IsFinally = isFinally;
            Type = type;
        }
    }
    public class ChargeUserWalletCommandHandler : IBaseCommandHandler<ChargeUserWalletCommand>
    {
        private readonly IUserRepository _repository;

        public ChargeUserWalletCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(ChargeUserWalletCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);

            if (user == null)
                return OperationResult.Success();
            var wallet = new Wallet(request.UserId, request.Price, request.Description, request.IsFinally, request.Type);
            user.ChargeWallet(wallet);
            await _repository.Save();
            return OperationResult.Success();
        }
    }

    public class ChargeUserWalletCommandValidator : AbstractValidator<ChargeUserWalletCommand>
    {
        public ChargeUserWalletCommandValidator()
        {
            RuleFor(w => w.Price)
                .NotNull().WithMessage(ValidationMessages.required("قیمت"))
                .NotEmpty().WithMessage(ValidationMessages.required("قیمت"))
                .GreaterThanOrEqualTo(1000).WithMessage("قیمت باید بیشتر از 1,0000 تومن باشد");

            RuleFor(w => w.Description)
                .NotNull().WithMessage(ValidationMessages.required("توضیحات"))
                .NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));

            RuleFor(w => w.Type)
                .NotNull().WithMessage(ValidationMessages.required("نوع"))
                .NotEmpty().WithMessage(ValidationMessages.required("نوع"));
        }
    }
}
