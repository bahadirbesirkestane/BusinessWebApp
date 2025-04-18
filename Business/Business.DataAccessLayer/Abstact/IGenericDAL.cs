﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.DataAccessLayer.Abstact
{
    public interface IGenericDAL<T> where T : class
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll();
        T GetById(int id);
        List<T> GetAll(Expression<Func<T, bool>> filter);
    }
}
