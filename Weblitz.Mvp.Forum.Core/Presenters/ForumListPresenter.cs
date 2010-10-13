using System;
using System.Collections.Generic;
using System.Linq;
using Weblitz.Mvp.Forum.Core.Mappers;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Core.Presenters
{
    public class ForumListPresenter
    {
        private readonly IForumListView _view;
        private readonly IForumProvider _provider;

        public ForumListPresenter(IForumListView view, IForumProvider provider)
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
            if (_view.IsPostBack) return;
            var list = _provider.List();
            _view.Forums = list == null ? null : list.Select(new ForumMapper().ToDisplay).ToList();
            _view.DataBind();
        }
    }
}