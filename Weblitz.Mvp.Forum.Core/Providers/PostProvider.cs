using System;
using System.Collections.Generic;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Providers
{
    public class PostProvider : IPostProvider
    {
        public IEnumerable<IPost> List()
        {
            throw new NotImplementedException();
        }

        public int Create(IPost entity)
        {
            throw new NotImplementedException();
        }

        public IPost Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(IPost entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}