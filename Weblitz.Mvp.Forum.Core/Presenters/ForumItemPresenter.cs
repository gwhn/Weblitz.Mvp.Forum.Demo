using System;
using Weblitz.Mvp.Forum.Core.Mappers;
using Weblitz.Mvp.Forum.Core.Models;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Core.Presenters
{
    public class ForumItemPresenter
    {
        private readonly IForumItemView _view;
        private readonly IForumProvider _provider;

        public ForumItemPresenter(IForumItemView view, IForumProvider provider)
        {
            _view = view;
            _provider = provider;

            _view.Load += Load;
            _view.Edit += Edit;
            _view.Delete += Delete;

            _view.NewTopic += NewTopic;
            _view.ShowTopic += ShowTopic;
        }

        private void ShowTopic(object sender, IdEventArgs e)
        {
            _view.GoToTopicItem(e.Id);
        }

        private void NewTopic(object sender, EventArgs e)
        {
            _view.GoToTopicForm(_view.CurrentId);
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
            if (_view.IsPostBack) return;
            _view.Forum = new ForumMapper().ToDisplay(_provider.Get(_view.CurrentId));
            _view.DataBind();
        }
    }
}