using System;

namespace Weblitz.Mvp.Forum.Core.Models
{
    public class Post : IPost
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public ITopic Topic { get; set; }
    }
}