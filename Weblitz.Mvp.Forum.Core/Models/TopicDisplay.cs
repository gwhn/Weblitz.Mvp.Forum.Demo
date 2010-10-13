using System;

namespace Weblitz.Mvp.Forum.Core.Models
{
    public class TopicDisplay : ITopicDisplay
    {
        public int Id { get; set; }
        public int ForumId { get; set; }
        public string Title { get; set; }
        public bool Sticky { get; set; }
    }
}