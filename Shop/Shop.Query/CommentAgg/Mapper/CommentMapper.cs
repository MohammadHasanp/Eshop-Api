using Shop.Domain.CommentAgg;
using Shop.Query.CommentAgg.Dtos;
using Shop.Query.CommentAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.CommentAgg.Mapper
{
    public static class CommentMapper
    {
        public static CommentDto Map(this Comment comment)
        {
            return new CommentDto()
            {
                CreationDate = comment.CreationDate,
                Id = comment.Id,
                Status = comment.Status,
                Text = comment.Text,
                ProductId = comment.ProductId,
                UserId = comment.UserId,
            };
        }
    }
}
