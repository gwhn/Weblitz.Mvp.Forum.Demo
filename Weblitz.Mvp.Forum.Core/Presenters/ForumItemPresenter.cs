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
            _view.Delete += Delete;
        }

        private void Delete(object sender, IdEventArgs e)
        {
            if (_provider.Delete(e.Id))
            {
                _view.GoToForumList();
            }
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