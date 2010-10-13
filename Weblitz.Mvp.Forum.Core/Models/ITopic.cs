namespace Weblitz.Mvp.Forum.Core.Models
{
    public interface ITopic : IEntity
    {
        string Title { get; set; }
        bool Sticky { get; set; }
        IForum Forum { get; set; }
    }
}