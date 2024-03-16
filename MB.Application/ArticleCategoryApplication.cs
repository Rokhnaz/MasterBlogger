using MB.Application.Contracts.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryAgg;
using MB.Domain.ArticleCategoryAgg.Services;

namespace MB.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticleCategoryValidatorService _articleCategoryValidatorService;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IArticleCategoryValidatorService articleCategoryValidatorService)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _articleCategoryValidatorService = articleCategoryValidatorService;
        }

        public void Activated(long id)
        {
            var ArticleCategory = _articleCategoryRepository.Get(id);
            ArticleCategory.Activate();
           // _articleCategoryRepository.SaveChanges();
        }

        public void create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title,_articleCategoryValidatorService);

            _articleCategoryRepository.Create(articleCategory);

        }

        public RenameArticleCategory GetBy(long id)
        {
            var ArticleCategory = _articleCategoryRepository.Get(id);
            return new RenameArticleCategory()
            {
                Id = ArticleCategory.Id,
                Title = ArticleCategory.Title,
            };
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            return articleCategories.Select(x => new ArticleCategoryViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                IsDeleted = x.IsDeleted,
                CreationDate = x.CreationDate.ToString(CultureInfo.InvariantCulture),
            }).OrderByDescending(x => x.Id).ToList();
        }

        public void Remove(long id)
        {
            var ArticleCategory = _articleCategoryRepository.Get(id);
            ArticleCategory.Remove();
            //_articleCategoryRepository.SaveChanges();
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            articleCategory.Rename(command.Title);
           // _articleCategoryRepository.SaveChanges();
        }

    }
}
