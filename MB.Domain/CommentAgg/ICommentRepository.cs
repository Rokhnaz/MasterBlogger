using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Infrastructure;
using MB.Application.Contracts.Comment;

namespace MB.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long,Comment> 
    {
        List<CommentViewModel> GetList();

        //void CreateAndSave(Comment entity);
        //void Save();
        //List<CommentViewModel> GetAll();
        //Comment Get(long id);
    }
}
