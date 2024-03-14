using MB.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.CommentAgg;
using Microsoft.EntityFrameworkCore;

namespace MB.Infrastructure.Query
{
    public class ArticleQuery:IArticleQuery
    {
        private readonly MasterBloggerContext _context;

        public ArticleQuery(MasterBloggerContext context)
        {
            _context = context;
        }
        public List<ArticleQueryView> GetArticles()
        {
            return _context.Articles
                .Include(x => x.ArticleCategory)
                .Include(x=>x.Comments)
                .Select(x => new ArticleQueryView()
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDiscription,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(),
                Image = x.Image,
                CommentsCount= x.Comments.Count(s=>s.Status==Statuses.Confirmed),
            }).ToList();
        }

        public ArticleQueryView GetArticle(long id)
        {
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView()
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDiscription,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(),
                Image = x.Image,
                Content = x.Content,
                CommentsCount = x.Comments.Count(s => s.Status == Statuses.Confirmed),
                 //Comments= x.Comments.Where(x=>x.Status==Statuses.Confirmed).Select(x=>new CommentQueryView(){Name = x.Name,CreationDate = x.CreationDate.ToString(),Message = x.Message}).ToList(),
                 Comments = MapComments(x.Comments.Where(z=>z.Status==Statuses.Confirmed)),
            }).FirstOrDefault(x => x.Id == id);
        }

        public static List<CommentQueryView> MapComments(IEnumerable<Comment> xComments)
        {
            return xComments.Select(x => new CommentQueryView()
                { Name = x.Name, CreationDate = x.CreationDate.ToString(), Message = x.Message }).ToList();

        }
    }
}
