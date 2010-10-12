using System;
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
            if (!_view.IsValid)
                return;
            if (_provider.Update(_view.Forum))
            {
                _view.GoToShowForum(e.Id);
            }
        }

        private void Create(object sender, EventArgs e)
        {
            if (!_view.IsValid)
                return;
            var id = _provider.Create(_view.Forum);
            if (id > 0)
            {
                _view.GoToShowForum(id);
            }
        }

        private void Load(object sender, EventArgs e)
        {
            if (_view.IsPostBack) return;
            var id = _view.CurrentId;
            if (id > 0)
            {
                var display = _provider.Get(id);
                _view.Forum = new ForumInput {Id = id, Name = display.Name};
            }
            else
            {
                _view.Forum = new ForumInput();
            }
        }
    }
}