﻿namespace Weblitz.Mvp.Forum.Core.Models
{
    public interface ITopicInput
    {
        int Id { get; set; }
        int ForumId { get; set; }
        string Title { get; set; }
        string Body { get; set; }
        bool Sticky { get; set; }
    }
}