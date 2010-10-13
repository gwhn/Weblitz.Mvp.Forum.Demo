using System;
using System.Collections.Generic;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Providers
{
    public interface IProvider<T> : IDisposable where T : IEntity 
    {
        IList<T> List();
        int Create(T entity);
        T Get(int id);
        bool Update(T entity);
        bool Delete(int id);
    }
}