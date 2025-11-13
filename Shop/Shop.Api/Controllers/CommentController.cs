using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Api.Infrastructure.Security;
using Shop.Api.ViewModel.Comments;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Edit;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.CommentAgg;
using Shop.Query.CommentAgg.DTOs;
using System.ComponentModel;
using System.Security.Cryptography.Xml;
using static Shop.Domain.CommentAgg.Comment;

namespace Shop.Api.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ICommentFacade _commentFacade;
        public CommentController(ICommentFacade commentFacade)
        {
            _commentFacade = commentFacade;
        }
        //[PermissionChecker(Permission.Comment_Management)]
        [HttpGet]
        public async Task<ApiResult<CommentFilterResult>> GetCommentByfilter([FromQuery] CommentFilterParams @params)
        {
            var result = await _commentFacade.GetCommentByFilter(@params);
            return QueryResult(result);
        }
        [AllowAnonymous]
        [HttpGet("ProductComments")]
        public async Task<ApiResult<CommentFilterResult>> GetProductComments([FromQuery]ProductCommentViewModel viewModel)
        {
            var result = await _commentFacade.GetCommentByFilter(new CommentFilterParams()
            {
                ProductId = viewModel.ProductId,
                Take = viewModel.Take,
                PageId = viewModel.PageId,
                Status = CommentStatus.Accepted,
            });
            return QueryResult(result);
        }
        [PermissionChecker(Permission.Comment_Management)]
        [HttpGet("{Id}")]
        public async Task<ApiResult<CommentDto>> GetcommnetById(long Id)
        {
            var result = await _commentFacade.GetCommentById(Id);
            return QueryResult(result);
        }
        //[Authorize]
        [HttpPost]
        public async Task<ApiResult> Createcomment(CreateCommentCommand command)
        {
            var result = await _commentFacade.Create(command);
            return CommandResult(result);
        }
        [Authorize]
        [HttpPut]
        public async Task<ApiResult> EditCommanet(EditCommentCommand command)
        {
            var result = await _commentFacade.Edit(command);
            return CommandResult(result);
        }
        [Authorize]
        [HttpPut("ChangeStatus")]
        public async Task<ApiResult> ChangeCommentStatus(ChangeCommentStatusCommand command)
        {
            var result = await _commentFacade.ChangeStatus(command);
            return CommandResult(result);
        }
        [HttpDelete("{commentId}")]
        public async Task<ApiResult> DeleteComment(long commentId)
        {
            var result = await _commentFacade.DeleteComment(commentId);
            return CommandResult(result);
        }
    }
}
