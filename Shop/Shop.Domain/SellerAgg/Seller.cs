using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Common.Domain.Exceptions.BaseDomainExceotion;

namespace Shop.Domain.SellerAgg
{
    public class Seller : AggregateRoot
    {
        //Relation With User
        public long UserId { get; private set; }
        //Shop Name Seller
        public string ShopName { get; private set; }
        //NationalCode Seller
        public string NationalCode { get; private set; }
        //Status Seller
        public SellerStatus Status { get; private set; }
        //
        public DateTime? LastUpdate { get; private set; }
        //Relation With SellerInvantory
        public List<SellerInventory> SellerInventories { get; private set; }
        //Set Seller
        public Seller(long userId, string shopName, string nationalCode, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            SellerInventories = new List<SellerInventory>();
            LastUpdate = DateTime.Now;
            Status = SellerStatus.New;
            if (domainService.IsUserIdExist(userId) || domainService.IsNationalCodeExist(nationalCode))
                throw new InvalidDomainDataException("اطلاعات نامعتبر است");

        }
        //For Efcore
        private Seller() { }
        //Change Status Seller
        //public void ChangeStatus(SellerStatus sellerStatus)
        //{
        //    Status = sellerStatus;
        //}
        //Edit ShopName,NationalCode
        public void Edit(string shopName, string nationalCode,SellerStatus status, ISellerDomainService domainService)
        {
            Guard(shopName, nationalCode);
            if (nationalCode != NationalCode)
                if (domainService.IsNationalCodeExist(nationalCode))
                    throw new InvalidDomainDataException("کد ملی متعلق به شخص دیگری است");

            ShopName = ShopName;
            NationalCode = nationalCode;
            Status = status;

        }
        //AddAsync Inventory For Seller 
        public void AddInventory(SellerInventory inventory)
        {
            if (SellerInventories.Any(i => i.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException("محصول قبلا ثبت شده است ");

            SellerInventories.Add(inventory);
        }
        //Edit Inventory Seller
        public void EditInventory(long inventoryId,int count,int price,int?discountPercentage)
        {
            var oldInventory = SellerInventories.FirstOrDefault(i => i.Id == inventoryId);
            if (oldInventory == null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");

            oldInventory.Edit(price, count, discountPercentage);

        }
        //Delete Inventory Seller
        public void DeleteInventory(long inventoryId)
        {
            var inventory = SellerInventories.FirstOrDefault(i => i.Id == inventoryId);
            if (inventory == null)
                throw new NullOrEmptyDomainDataException("محصول یافت نشد");
            SellerInventories.Remove(inventory);

        }
        //Validation Seller
        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString((shopName, nameof(shopName)), (nationalCode, nameof(nationalCode)));

            if (!IranianNationalIdChecker.IsValid(nationalCode))
                throw new InvalidDomainDataException("کدملی نامعتبر است");
        }

    }
}
