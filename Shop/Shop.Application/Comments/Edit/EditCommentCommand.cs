using Common.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Comments.Edit
{
    public record EditCommentCommand(long Id, string text, long userId, long productId) : IBaseCommand;
}
