using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MB.Domain.ArticleCategoryAgg.Services
{
    public class ArticleCategoryValidatorService:IArticleCategoryValidatorService
    {
        private  readonly  IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryValidatorService(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository; 
        }
        public void CheckThatThisRecordAlreadyExists(string title)
        {
            if (_articleCategoryRepository.Exist(title))
                throw new Exception();
        }
    }
}
