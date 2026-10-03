
using Common.Application;
using Shop.Domain.CommentAgg.Repository;

namespace Shop.Application.Comments.Delete
{
    public record DeleteCommentCommand(long CommentId):IBaseCommand;

    public class DeleteCommentHandler : IBaseCommandHandler<DeleteCommentCommand>
    {
        private readonly ICommentRepository _repository;
        public DeleteCommentHandler(ICommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = await _repository.GetTracking(request.CommentId);
            if (comment == null)
                return OperationResult.NotFound();

            _repository.Delete(comment);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
