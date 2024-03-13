using MB.Infrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return _context.Articles.Include(x => x.ArticleCategory).Select(x => new ArticleQueryView()
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDiscription,
                ArticleCategory = x.ArticleCategory.Title,
                CreationDate = x.CreationDate.ToString(),
                Image = x.Image,
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
                Content = x.Content
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
