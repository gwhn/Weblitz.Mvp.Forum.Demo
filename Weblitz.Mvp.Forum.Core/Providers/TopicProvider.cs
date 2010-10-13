using System;
using System.Collections.Generic;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Providers
{
    public class TopicProvider : ITopicProvider
    {
        public IEnumerable<ITopic> List()
        {
            throw new NotImplementedException();
        }

        public int Create(ITopic entity)
        {
            throw new NotImplementedException();
        }

        public ITopic Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(ITopic entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}