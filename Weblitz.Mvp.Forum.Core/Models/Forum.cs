using System;
using System.Collections.Generic;

namespace Weblitz.Mvp.Forum.Core.Models
{
    public class Forum : IForum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ITopic> Topics { get; set; }
    }
}