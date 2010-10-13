using System;
using Weblitz.Mvp.Forum.Core.Mappers;
using Weblitz.Mvp.Forum.Core.Models;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Core.Presenters
{
    public class ForumFormPresenter
    {
        private readonly IForumFormView _view;
        private readonly IForumProvider _provider;

        public ForumFormPresenter(IForumFormView view, IForumProvider provider)
        {
            _view = view;
            _provider = provider;

            _view.Load += Load;
            _view.Create += Create;
            _view.Update += Update;
        }

        private void Update(object sender, IdEventArgs e)
        {
            if (!_view.IsValid) return;
            if (_provider.Update(new ForumMapper().FromInput(_view.Forum))) _view.GoToShowForum(e.Id);
        }

        private void Create(object sender, EventArgs e)
        {
            if (!_view.IsValid) return;
            var id = _provider.Create(new ForumMapper().FromInput(_view.Forum));
            if (id > 0) _view.GoToShowForum(id);
        }

        private void Load(object sender, EventArgs e)
        {
            if (_view.IsPostBack) return;
            var id = _view.CurrentId;
            _view.Forum = id > 0 ? new ForumMapper().ToInput(_provider.Get(id)) : new ForumInput();
        }
    }
}