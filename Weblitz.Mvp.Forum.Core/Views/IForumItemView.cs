﻿using System;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Views
{
    public interface IForumItemView : IView
    {
        IForumDisplay Forum { get; set; }
        int CurrentId { get; }
        event EventHandler<IdEventArgs> Edit;
        void GoToForumForm(int id);
        event EventHandler<IdEventArgs> Delete;
        void GoToForumList();
    }
}