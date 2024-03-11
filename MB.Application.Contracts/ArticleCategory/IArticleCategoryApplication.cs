using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Application.Contracts.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        List<ArticleCategoryViewModel> List();
        void create(CreateArticleCategory command);
        void Rename(RenameArticleCategory command);
        RenameArticleCategory GetBy(long  id);
        void Remove(long id);
        void Activated(long id);

    }
}
