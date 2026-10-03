using Shop.Application.Users.Register;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.UserAgg.Services
{
    public class UserDomainService : IUserDomainService
    {
        private readonly IUserRepository _repository;
        public UserDomainService(IUserRepository repository)
        {
            _repository = repository;
        }
        public bool IsEmailExist(string email)
        {
            return _repository.Exists(u=>u.Email == email);
        }

        public bool IsPhoneNumberExist(string phone)
        {
            return _repository.Exists(u=>u.PhoneNumber == phone);
        }
    }
}
