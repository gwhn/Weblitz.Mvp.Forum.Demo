using System;
using Weblitz.Mvp.Forum.Core.Mappers;
using Weblitz.Mvp.Forum.Core.Models;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Core.Presenters
{
    public class TopicFormPresenter
    {
        private readonly ITopicFormView _view;
        private readonly ITopicProvider _provider;

        public TopicFormPresenter(ITopicFormView view, ITopicProvider provider)
        {
            _view = view;
            _provider = provider;

            _view.Load += Load;
            _view.Create += Create;
        }

        private void Create(object sender, EventArgs e)
        {
            if (!_view.IsValid) return;
            var id = _provider.Create(new TopicMapper().FromInput(_view.Topic));
            if (id > 0) _view.GoToShowTopic(id);
        }

        private void Load(object sender, EventArgs e)
        {
            if (_view.IsPostBack) return;
            var id = _view.CurrentId;
            _view.Topic = id > 0 ? new TopicMapper().ToInput(_provider.Get(id)) : new TopicInput { ForumId = _view.ParentId };
        }
    }
}