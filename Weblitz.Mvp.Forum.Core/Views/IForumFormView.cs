using System;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Views
{
    public interface IForumFormView : IView
    {
        IForumInput Forum { get; set; }
        int CurrentId { get; }
        event EventHandler Create;
        void GoToShowForum(int id);
    }
}