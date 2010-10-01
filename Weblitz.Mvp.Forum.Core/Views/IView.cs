using System;

namespace Weblitz.Mvp.Forum.Core.Views
{
    public interface IView
    {
        event EventHandler Load;
        bool IsPostBack { get; }
        void DataBind();
    }
}