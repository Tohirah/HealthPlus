﻿using System.Linq.Expressions;

namespace HealthPlus.Application.Interfaces.Repositories
{
    public interface IRepository
    {
        T Add<T>(T entity) where T : class, new();
        T Delete<T>(T entity) where T : class, new();
        T Update<T>(T entity) where T : class, new();
        T Get<T>(Expression<Func<T, bool>> expression) where T : class, new();
        IList<T> GetAll<T>(Expression<Func<T, bool>> expression = null) where T : class, new();
        int SaveChanges();
    }
}
