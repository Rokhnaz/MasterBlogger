using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _commentApplication;

        public CommentApplication(ICommentRepository commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void Add(AddComment command)
        {
            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
           _commentApplication.CreateAndSave(comment);
           _commentApplication.Save();
        }
    }
}
