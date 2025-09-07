using Microsoft.EntityFrameworkCore;
using Shop.Domain.UserAgg;
using Shop.Infrastructure.Persistent.Ef._Context;
using Shop.Query.UserAgg.DTOs;

namespace Shop.Query.UserAgg.Mapper
{
    public static class UserMapper
    {
        public static UserDto Map(this User user)
        {
            return new UserDto()
            {
                UserName = user.UserName,
                AvatarName = user.AvatarName,
                CreationDate = user.CreationDate,
                Email = user.Email,
                FullName = user.FullName,
                Gender = user.Gender,
                IsActive = user.IsActive,
                Password = user.Password,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                Roles = user.Roles.Select(u => new UserRoleDto()
                {
                    RoleId = u.RoleId,
                    RoleTitle =""
                }).ToList()
            };
        }
        public static async Task<UserDto> SetUserRoleTitles(this UserDto user,ShopContext context)
        {
            var roleIds = user.Roles.Select(r=>r.RoleId);
            var result =await context.Roles.Where(r => roleIds.Contains(r.Id)).ToListAsync();
            var roles = new List<UserRoleDto>();
            foreach (var role in result)
            {
                roles.Add(new UserRoleDto()
                {
                    RoleId = role.Id,
                    RoleTitle = role.Title
                });
            }
            user.Roles = roles;
            return user;
        }
        public static async Task<List<UserDto>> SetUsersRolesTitles(this List<UserDto> users, ShopContext context)
        {
            var roleIds = new List<long?>();
            users.ForEach(u =>
            {
                u.Roles.ForEach(r =>
                {
                    roleIds.Add(r.RoleId);
                });
            });
            //check
            var result = await context.Roles.Where(r=>roleIds.Contains(r.Id)).ToListAsync();
            var roles = new List<UserRoleDto>();
            foreach (var role in result)
            {
                roles.Add(new UserRoleDto()
                {
                    RoleId = role.Id,
                    RoleTitle = role.Title
                });
            }
            users.ForEach(u =>
            {
                u.Roles = roles;
            });
            return users;
        }

        public static UserFilterData MapFilterData(this User user)
        {
            return new UserFilterData()
            {
                Id = user.Id,
                AvatarName = user.AvatarName,
                UserName = user.UserName,
                CreationDate = user.CreationDate,
                Email = user.Email,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber
            };
        }

        public static List<UserDto> MapList(this List<User> user)
        {
            var users = new List<UserDto>();
            user.ForEach(user =>
            {
                users.Add(new UserDto()
                {
                    UserName = user.UserName,
                    AvatarName = user.AvatarName,
                    CreationDate = user.CreationDate,
                    Email = user.Email,
                    FullName = user.FullName,
                    Gender = user.Gender,
                    Password = user.Password,
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    Roles = user.Roles.Select(u => new UserRoleDto()
                    {
                        RoleId = u.RoleId,
                        RoleTitle = ""
                    }).ToList()
                });
            });
            return users;
        }
    }
}
