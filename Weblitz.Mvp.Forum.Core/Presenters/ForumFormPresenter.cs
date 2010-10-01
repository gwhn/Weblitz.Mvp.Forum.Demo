using System;
using Weblitz.Mvp.Forum.Core.Models;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Core.Presenters
{
    public class ForumFormPresenter
    {
        private IForumFormView _view;
        private IForumProvider _provider;

        public ForumFormPresenter(IForumFormView view, IForumProvider provider)
        {
            _view = view;
            _provider = provider;

            _view.Load += Load;
        }

        private void Load(object sender, EventArgs e)
        {
            if (!_view.IsPostBack)
            {
                _view.Forum = new ForumInput();
            }

        }
    }
}