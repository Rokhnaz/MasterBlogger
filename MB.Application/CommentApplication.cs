using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Application.Contracts.Comment;

namespace MB.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentApplication _commentApplication;

        public CommentApplication(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }
    }
}
