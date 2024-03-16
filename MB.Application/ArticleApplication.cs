using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Infrastructure;
using MB.Application.Contracts.Article;
using MB.Domain.ArticleAgg;

namespace MB.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitofWork _unitofWork;

        public ArticleApplication(IArticleRepository articleRepository, IUnitofWork unitofWork)
        {
            _articleRepository = articleRepository;
            _unitofWork = unitofWork;
        }
        public void Create(CreateArticle command)
        {
            _unitofWork.BeginTran();

            var article = new Article(command.Title, command.shortDescription, command.Image, command.Content,
                command.ArticleCategoryId);
            _articleRepository.Create(article);

            _unitofWork.CommitTran();

        }

        public void Edit(EditArticle command)
        {
            _unitofWork.BeginTran();

            var article = _articleRepository.Get(command.Id);
            article.Edit(command.Title,command.shortDescription,command.Image,command.Content,command.ArticleCategoryId);
            //_articleRepository.Save();

            _unitofWork.CommitTran();
        }

        public EditArticle Get(long id)
        {
            var article= _articleRepository.Get(id);
            return new EditArticle()
            {
                Id = article.Id,
                Title = article.Title,
                shortDescription = article.ShortDiscription,
                Image = article.Image,
                Content = article.Content,
                ArticleCategoryId = article.ArticleCategoryId
            };
        }

        public void Remove(long id)
        {
            _unitofWork.BeginTran();

           var article= _articleRepository.Get(id);
           article.Remove();
           //_articleRepository.Save();

           _unitofWork.CommitTran();

        }

        public void Activate(long id)
        {
            _unitofWork.BeginTran();

            var article = _articleRepository.Get(id);
            article.Activate();
            //_articleRepository.Save();

            _unitofWork.CommitTran();
        }

        public List<ArticleViewModel> GetList()
        {
            return _articleRepository.GetList();
        }
    }
}
