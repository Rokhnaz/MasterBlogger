﻿using MB.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Infrastructure;

namespace MB.Infrastructure.EFCore.Repositories
{
    public class ArticleCategoryRepository:BaseRepository<long,ArticleCategory>,IArticleCategoryRepository
    {
        private readonly MasterBloggerContext _context;

        public ArticleCategoryRepository(MasterBloggerContext context):base(context)
        {
            _context = context; 
        }

    }
}
