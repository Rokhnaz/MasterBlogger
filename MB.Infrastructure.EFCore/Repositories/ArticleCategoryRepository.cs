using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository:IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context)
        {
            _context = context; 
        }
        public void Add(ArticleCategory entity)
        {
            _context.ArticleCategories.Add(entity);
            SaveChanges();
        }

        public bool Exist(string title)
        {
            return _context.ArticleCategories.Any(t => t.Title == title);
        }

        public List<ArticleCategory> GetAll()
        {
            return _context.ArticleCategories.OrderByDescending(i=>i.Id).ToList();
        }

        public ArticleCategory GetBy(long id)
        {
            return _context.ArticleCategories.FirstOrDefault(i => i.Id == id);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }


    }
}
