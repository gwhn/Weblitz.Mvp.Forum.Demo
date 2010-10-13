using System;
using System.Collections.Generic;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Providers
{
    public class ForumProvider : IForumProvider
    {
        private static int _counter = 0;

        public IEnumerable<IForum> List()
        {
            return new List<IForum> {new Models.Forum {Id = 321, Name = "First Feature Forum"}};
        }

        public int Create(IForum entity)
        {
            return ++_counter;
        }

        public IForum Get(int id)
        {
            return new Models.Forum {Id = id, Name = "Fetched Forum by Id"};
        }

        public bool Update(IForum entity)
        {
            return true;
        }

        public bool Delete(int id)
        {
            return true;
        }
    }
}