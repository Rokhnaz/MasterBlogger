using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MB.Domain.ArticleCategoryAgg;

namespace MB.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get;private set; }
        public string Title { get; private set; }
        public string ShortDiscription { get; private set; }
        public string Image { get; private set; }
        public string Content { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime CreationDate { get; private set; }
        public long ArticleCategoryId { get; private set; }
        public ArticleCategory ArticleCategory { get; private set; }


        protected Article()
        {
            
        }

        public Article( string title, string shortDiscription, string image, string content, long articleCategoryId)
        {
            Title = title;
            ShortDiscription = shortDiscription;
            Image = image;
            Content = content;
            IsDeleted = false;
            CreationDate = DateTime.Now;
            ArticleCategoryId = articleCategoryId;  
        }

        public void Edit(string title, string shortDiscription, string image, string content, long articleCategoryId)
        {
            Title = title;
            ShortDiscription = shortDiscription;
            Image = image;
            Content = content;
            ArticleCategoryId = articleCategoryId;
        }

        public void Remove()
        {
            IsDeleted = true;
        }

        public void Activate()
        {
            IsDeleted = false;
        }
    }
}
