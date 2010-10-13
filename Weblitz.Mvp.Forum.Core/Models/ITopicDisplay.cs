namespace Weblitz.Mvp.Forum.Core.Models
{
    public interface ITopicDisplay
    {
        int Id { get; set; }
        int ForumId { get; set; }
        string Title { get; set; }
        bool Sticky { get; set; }
    }
}