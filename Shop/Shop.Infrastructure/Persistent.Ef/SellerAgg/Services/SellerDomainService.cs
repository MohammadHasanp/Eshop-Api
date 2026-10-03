using Shop.Domain.SellerAgg.Repository;
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
        private readonly ISellerRepository _repository;
        public SellerDomainService(ISellerRepository repository)
        {
            _repository = repository;
        }
        public bool IsNationalCodeExist(string natinalCode)
        {
            return _repository.Exists(s=>s.NationalCode == natinalCode);
        }

        public bool IsUserIdExist(long UserId)
        {
            return _repository.Exists(s=>s.UserId == UserId);
        }
    }
}
