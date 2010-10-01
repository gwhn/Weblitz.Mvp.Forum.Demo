using System;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Core.Presenters
{
    public class ForumPresenter
    {
        private IForumListView _view;
        private IForumProvider _provider;

        public ForumPresenter(IForumListView view, IForumProvider provider)
        {
            _view = view;
            _provider = provider;

            _view.Load += Load;
            _view.New += New;
            _view.Show += Show;

        }

        private void Show(object sender, IdEventArgs e)
        {
            _view.GoToForumItem(e.Id);
        }

        private void New(object sender, EventArgs e)
        {
            _view.GoToForumForm();
        }

        private void Load(object sender, EventArgs e)
        {
            if (!_view.IsPostBack)
            {
                _view.Forums = _provider.List();
                _view.DataBind();
            }
        }
    }
}