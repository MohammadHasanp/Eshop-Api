using Common.Application;
using Common.Application.FileUtil.Interfaces;
using Microsoft.AspNetCore.Http;
using Shop.Application._Utilities;
using Shop.Domain.UserAgg.Repository;
using Shop.Domain.UserAgg.Services;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserDomainService _domainService;
        IUserRepository _repository;
        IFileService _fileService;

        public EditUserCommandHandler(IUserDomainService domainService, IUserRepository repository
            , IFileService fileService)
        {
            _domainService = domainService;
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);

            if (user == null)
                return OperationResult.NotFound();

            var oldImage = user.AvatarName;
            user.Edit(request.UserName, request.FullName, request.Email, request.PhoneNumber, request.Gender, _domainService);

            if (request.Avatar != null)
            {
                var avatarName = await _fileService.SaveFileAndGenerateName(request.Avatar, Directories.UserAvatars);
                user.SetAvatar(avatarName);
            }

            await _repository.Save();
            RemoveAvatarOld(request.Avatar, oldImage);
            return OperationResult.Success();
        }
        private void RemoveAvatarOld(IFormFile? avatarFile, string avatarName)
        {
            if (avatarFile == null || avatarName == "avatar.png")
                return;
            _fileService.DeleteFile(Directories.UserAvatars, avatarName);
        }
    }
}