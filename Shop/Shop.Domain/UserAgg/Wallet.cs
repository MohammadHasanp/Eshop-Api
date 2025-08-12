using Common.Domain;
using Shop.Domain.UserAgg.Enums;
using static Common.Domain.Exceptions.BaseDomainExceotion;

namespace Shop.Domain.UserAgg
{
    public class Wallet:BaseEntity
    {
        public long UserId{ get;internal set; }
        public int Price { get; private set; }
        public string Decription { get; private set; }
        public bool IsFinally { get; private set; }
        public DateTime? FinallyDate { get; private set; }
        public WalletType Type { get; set; }
        public void Finally(string refCode)
        {
            FinallyDate = DateTime.Now;
            IsFinally = true;
            Decription += $"کد پیگیری : {refCode}";
        }
        public void Finally()
        {
            FinallyDate = DateTime.Now;
            IsFinally = true;
        }

        public Wallet(long userId, int price, string decription, bool isFinally, DateTime? finallyDate, WalletType type)
        {
            if (price > 500)
                throw new InvalidDomainDataException();
            Price = price;
            Decription = decription;
            IsFinally = isFinally;
            FinallyDate = finallyDate;
            Type = type;
        }
    }
}
