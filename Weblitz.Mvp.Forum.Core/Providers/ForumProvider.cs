using System;
using System.Collections.Generic;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Providers
{
    public class ForumProvider : IForumProvider
    {
        public IEnumerable<IForumDisplay> List()
        {
            return new List<IForumDisplay> {new ForumDisplay {Name = "First Feature Forum"}};
        }
    }
}