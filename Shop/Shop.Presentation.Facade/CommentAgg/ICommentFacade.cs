using Common.Application;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Delete;
using Shop.Application.Comments.Edit;
using Shop.Query.CommentAgg.DTOs;

namespace Shop.Presentation.Facade.CommentAgg
{
    public interface ICommentFacade
    {
        Task<OperationResult> Create(CreateCommentCommand command);
        Task<OperationResult> Edit(EditCommentCommand command);
        Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command);
        Task<OperationResult> DeleteComment(long commentId);

        Task<CommentDto> GetCommentById(long Id);
        Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams @params);
    }
}
