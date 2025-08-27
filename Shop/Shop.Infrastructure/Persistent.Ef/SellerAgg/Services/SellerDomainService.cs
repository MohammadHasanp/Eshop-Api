using Shop.Domain.SellerAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.SellerAgg.Services
{
    public class SellerDomainService : ISellerDomainService
    {
        public bool IsNationalCodeExist(string natinalCode)
        {
            throw new NotImplementedException();
        }

        public bool IsUserIdExist(long UserId)
        {
            throw new NotImplementedException();
        }
    }
}
