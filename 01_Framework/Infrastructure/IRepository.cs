﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _01_Framework.Domain;

namespace _01_Framework.Infrastructure
{
    // T hatman bayad celasi bashad ke az domainbase ers bari kede bashad
    public interface IRepository<in TKey, T> where T:DomainBase<TKey>
    {
        void Create(T entity);
        T Get(TKey id);
        List<T> GetAll();
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
