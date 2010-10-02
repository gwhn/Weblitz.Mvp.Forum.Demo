using System;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Core.Presenters
{
    public class ForumItemPresenter
    {
        private IForumItemView _view;
        private IForumProvider _provider;

        public ForumItemPresenter(IForumItemView view, IForumProvider provider)
        {
            _view = view;
            _provider = provider;

            _view.Load += Load;
            _view.Edit += Edit;
        }

        private void Edit(object sender, IdEventArgs e)
        {
            _view.GoToForumForm(e.Id);
        }

        private void Load(object sender, EventArgs e)
        {
            if (!_view.IsPostBack)
            {
                _view.Forum = _provider.Get(_view.CurrentId);
            }
        }
    }
}