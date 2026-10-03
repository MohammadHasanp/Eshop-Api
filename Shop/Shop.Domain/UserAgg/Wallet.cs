using Common.Domain;
using Shop.Domain.UserAgg.Enums;
using static Common.Domain.Exceptions.BaseDomainExceotion;

namespace Shop.Domain.UserAgg
{
    public class Wallet:BaseEntity
    {
        private Wallet() { }
        //Relation With User
        public long UserId{ get;internal set; }
        //Amount Wallet User
        public int Price { get; private set; }
        //
        public string Description { get; private set; }
        //
        public bool IsFinally { get; private set; }
        //
        public DateTime? FinallyDate { get; private set; }
        //Type Wallet User
        public WalletType Type { get; set; }
        //
        public void Finally(string refCode)
        {
            FinallyDate = DateTime.Now;
            IsFinally = true;
            Description += $"کد پیگیری : {refCode}";
        }
        //
        public void Finally()
        {
            FinallyDate = DateTime.Now;
            IsFinally = true;
        }
        //Set Wallet
        public Wallet(long userId, int price, string decription, bool isFinally, WalletType type)
        {
            if (price > 500)
                throw new InvalidDomainDataException();
            Price = price;
            Description = decription;
            IsFinally = isFinally;
            Type = type;
            if(IsFinally == true)
                FinallyDate = DateTime.Now;
        }
    }
}
