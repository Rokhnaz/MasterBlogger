using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;
using MB.Domain.CommentAgg;

namespace MB.Application
{
    public class CommentApplication:ICommentApplication
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IUnitofWork _unitofWork;

        public CommentApplication(ICommentRepository commentRepository, IUnitofWork unitofWork)
        {
            _commentRepository = commentRepository;
            _unitofWork = unitofWork;   
        }

        public void Add(AddComment command)
        {
            _unitofWork.BeginTran();

            var comment = new Comment(command.Name, command.Email, command.Message, command.ArticleId);
            _commentRepository.Create(comment);
           // _commentRepository.Save();

           _unitofWork.CommitTran();
        }

        public List<CommentViewModel> GetList()
        {
            return _commentRepository.GetList();
        }

        public void Confirm(long id)
        {
            _unitofWork.BeginTran();

            var comment = _commentRepository.Get(id);
            comment.Confirm();
           // _commentRepository.Save();

           _unitofWork.CommitTran();
        }

        public void Cancel(long id)
        {
            _unitofWork.BeginTran();

            var comment = _commentRepository.Get(id);
            comment.Cancel();
           // _commentRepository.Save();

           _unitofWork.CommitTran();
        }
    }
}
