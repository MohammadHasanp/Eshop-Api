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
using static Shop.Domain.CommentAgg.Comment;

namespace Shop.Api.Controllers
{
    public class CommentController(ICommentFacade commentFacade) : ApiController
    {
        //[PermissionChecker(Permission.Comment_Management)]
        [HttpGet]
        public async Task<ApiResult<CommentFilterResult>> GetCommentByfilter([FromQuery] CommentFilterParams @params)
        {
            var result = await commentFacade.GetCommentByFilter(@params);
            return QueryResult(result);
        }
        [AllowAnonymous]
        [HttpGet("ProductComments")]
        public async Task<ApiResult<CommentFilterResult>> GetProductComments([FromQuery]ProductCommentViewModel viewModel)
        {
            var result = await commentFacade.GetCommentByFilter(new CommentFilterParams()
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
            var result = await commentFacade.GetCommentById(Id);
            return QueryResult(result);
        }
        //[Authorize]
        [HttpPost]
        public async Task<ApiResult> Createcomment(CreateCommentCommand command)
        {
            var result = await commentFacade.Create(command);
            return CommandResult(result);
        }
        [Authorize]
        [HttpPut]
        public async Task<ApiResult> EditCommanet(EditCommentCommand command)
        {
            var result = await commentFacade.Edit(command);
            return CommandResult(result);
        }
        [Authorize]
        [HttpPut("ChangeStatus")]
        public async Task<ApiResult> ChangeCommentStatus(ChangeCommentStatusCommand command)
        {
            var result = await commentFacade.ChangeStatus(command);
            return CommandResult(result);
        }
        [HttpDelete("{commentId}")]
        public async Task<ApiResult> DeleteComment(long commentId)
        {
            var result = await commentFacade.DeleteComment(commentId);
            return CommandResult(result);
        }
    }
}
