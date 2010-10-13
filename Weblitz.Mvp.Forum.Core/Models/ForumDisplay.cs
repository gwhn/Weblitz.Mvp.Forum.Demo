using System;
using System.Collections.Generic;

namespace Weblitz.Mvp.Forum.Core.Models
{
    public class ForumDisplay : IForumDisplay
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ITopicDisplay> Topics { get; set; }
    }
}