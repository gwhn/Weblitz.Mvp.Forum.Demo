using System;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Views
{
    public interface ITopicFormView : IView
    {
        event EventHandler Create;
        ITopicInput Topic { get; set; }
        int CurrentId { get; set; }
        int ParentId { get; }
        void GoToShowTopic(int id);
    }
}