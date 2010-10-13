using System.Collections.Generic;

namespace Weblitz.Mvp.Forum.Core.Models
{
    public interface ITopic : IEntity
    {
        string Title { get; set; }
        string Body { get; set; }
        bool Sticky { get; set; }
        IForum Forum { get; set; }
        IList<IPost> Posts { get; set; }
    }
}