using System;
using System.Collections.Generic;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Providers
{
    public class ForumProvider : IForumProvider
    {
        private static int _counter = 0;

        public IEnumerable<IForumDisplay> List()
        {
            return new List<IForumDisplay> {new ForumDisplay {Id = 321, Name = "First Feature Forum"}};
        }

        public int Create(IForumInput forum)
        {
            return ++_counter;
        }

        public IForumDisplay Get(int id)
        {
            return new ForumDisplay {Id = id, Name = "Fetched Forum by Id"};
        }

        public bool Update(IForumInput forum)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}