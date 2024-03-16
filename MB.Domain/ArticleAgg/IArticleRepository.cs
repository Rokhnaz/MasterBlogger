using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Infrastructure;
using MB.Application.Contracts.Article;


namespace MB.Domain.ArticleAgg
{
    public interface IArticleRepository:IRepository<long,Article>
    {
        List<ArticleViewModel> GetList();

        //List<ArticleViewModel> GetAll();
        //void CreateAndSave(Article article);
        //void Save();
        //Article Get(long id);
        //bool Exists(string title);
    }
}
