using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.SellerAgg.Enums;
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
        public SellerStatus SellerStatus { get; private set; }
        //
        public DateTime? LastUpdate { get; private set; }
        //Relation With SellerInvantory
        public List<SellerInventory> SellerInventories { get; private set; }
        //Set Seller
        public Seller(long userId, string shopName, string nationalCode)
        {
            Guard(shopName, nationalCode);
            UserId = userId;
            ShopName = shopName;
            NationalCode = nationalCode;
            SellerInventories = new List<SellerInventory>();
            LastUpdate = DateTime.Now;
        }
        //For Efcore
        private Seller() { }
        //Change Status Seller
        public void ChangeStatus(SellerStatus sellerStatus)
        {
            SellerStatus = sellerStatus;
        }
        //Edit ShopName,NationalCode
        public void Edit(string shopName, string nationalCode)
        {
            Guard(shopName, nationalCode);
            ShopName = ShopName;
            NationalCode = nationalCode;
        }
        //Add Inventory For Seller 
        public void AddInventory(SellerInventory inventory)
        {
            if (SellerInventories.Any(i => i.ProductId == inventory.ProductId))
                throw new InvalidDomainDataException("Product InValid");
        }
        //Edit Inventory Seller
        public void EditInventory(SellerInventory newInventory)
        {
            var oldInventory = SellerInventories.FirstOrDefault(i => i.Id == newInventory.Id);
            if (oldInventory == null)
                throw new NullOrEmptyDomainDataException("Not Found Inventory");
            SellerInventories.Remove(oldInventory);
            SellerInventories.Add(newInventory);
        }
        //Delete Inventory Seller
        public void DeleteInventory(long inventoryId)
        {
            var inventory = SellerInventories.FirstOrDefault(i=>i.Id == inventoryId);
            if (inventory == null)
                throw new NullOrEmptyDomainDataException("Not Found Inventory");
            SellerInventories.Remove(inventory);

        }
        //Validation Seller
        public void Guard(string shopName, string nationalCode)
        {
            NullOrEmptyDomainDataException.CheckString((shopName, nameof(shopName)), (nationalCode, nameof(nationalCode)));

            if (!IranianNationalIdChecker.IsValid(nationalCode))
                throw new InvalidDomainDataException("NationalCode InValid");
        }

    }
}
