using System;
using System.Collections.Generic;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Views
{
    public interface IForumListView : IView
    {
        IEnumerable<IForumDisplay> Forums { get; set; }
        event EventHandler<IdEventArgs> Show;
        event EventHandler New;
        void GoToForumForm();
        void GoToForumItem(int id);
    }
}