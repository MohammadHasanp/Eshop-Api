using Common.Application;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.Edit
{
    public class EditCommentCommandHandler : IBaseCommandHandler<EditCommentCommand>
    {
        private readonly ICammentRepository _repository;

        public EditCommentCommandHandler(ICammentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(EditCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetTracking(request.Id);

            if (comment == null||comment.UserId != request.userId)
                return OperationResult.NotFound();

            comment.Edit(request.text);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
