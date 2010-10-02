using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Views
{
    public interface IForumItemView : IView
    {
        IForumDisplay Forum { get; set; }
        int CurrentId { get; set; }
    }
}