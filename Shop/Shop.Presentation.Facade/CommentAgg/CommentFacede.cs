using Common.Application;
using MediatR;
using Shop.Application.Comments.ChangeStatus;
using Shop.Application.Comments.Create;
using Shop.Application.Comments.Delete;
using Shop.Application.Comments.Edit;
using Shop.Query.CommentAgg.DTOs;
using Shop.Query.CommentAgg.GetByFilter;
using Shop.Query.CommentAgg.GetById;

namespace Shop.Presentation.Facade.CommentAgg
{
    public class CommentFacede : ICommentFacade
    {
        private readonly IMediator _mediator;
        public CommentFacede(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<OperationResult> ChangeStatus(ChangeCommentStatusCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> Create(CreateCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<OperationResult> DeleteComment(long commentId)
        {
            return await _mediator.Send(new DeleteCommentCommand(commentId));
        }

        public async Task<OperationResult> Edit(EditCommentCommand command)
        {
            return await _mediator.Send(command);
        }

        public async Task<CommentFilterResult> GetCommentByFilter(CommentFilterParams @params)
        {
            return await _mediator.Send(new GetCommentByFilterQuery(@params));
        }

        public async Task<CommentDto> GetCommentById(long Id)
        {
            return await _mediator.Send(new GetCommentByIdQuery(Id));
        }
    }
}
