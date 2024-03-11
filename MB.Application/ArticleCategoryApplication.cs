using MB.Application.Contracts.ArticleCategory;
using System;
using System.Collections.Generic;
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
            var ArticleCategory = _articleCategoryRepository.GetBy(id);
            ArticleCategory.Activate();
            _articleCategoryRepository.SaveChanges();
        }

        public void create(CreateArticleCategory command)
        {
            var articleCategory = new ArticleCategory(command.Title,_articleCategoryValidatorService);
            _articleCategoryRepository.Add(articleCategory);

        }

        public RenameArticleCategory GetBy(long id)
        {
            var ArticleCategory = _articleCategoryRepository.GetBy(id);
            return new RenameArticleCategory()
            {
                Id = ArticleCategory.Id,
                Title = ArticleCategory.Title,
            };
        }

        public List<ArticleCategoryViewModel> List()
        {
            var articleCategories = _articleCategoryRepository.GetAll();
            List<ArticleCategoryViewModel> ACViewModel= new List<ArticleCategoryViewModel>();
            foreach (var item in articleCategories)
            {
                var ac = new ArticleCategoryViewModel();
                ac.Id = item.Id;
                ac.Title = item.Title;
                ac.IsDeleted = item.IsDeleted;
                ac.CreationDate = item.CreationDate.ToString();

                ACViewModel.Add(ac);
            }

            return ACViewModel;
        }

        public void Remove(long id)
        {
            var ArticleCategory = _articleCategoryRepository.GetBy(id);
            ArticleCategory.Remove();
            _articleCategoryRepository.SaveChanges();
        }

        public void Rename(RenameArticleCategory command)
        {
            var articleCategory = _articleCategoryRepository.GetBy(command.Id);
            articleCategory.Rename(command.Title);
            _articleCategoryRepository.SaveChanges();
        }

    }
}
