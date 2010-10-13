using System;
using System.Collections.Generic;

namespace Weblitz.Mvp.Forum.Core.Models
{
    public class Topic : ITopic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public bool Sticky { get; set; }
        public IForum Forum { get; set; }
        public IList<IPost> Posts { get; set; }
    }
}