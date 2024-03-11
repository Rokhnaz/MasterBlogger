using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository
    {
        List<ArticleCategory> GetAll();
        void Add(ArticleCategory entity);
        void SaveChanges();
        ArticleCategory GetBy(long  id);
        bool Exist(string title);

    }
}
