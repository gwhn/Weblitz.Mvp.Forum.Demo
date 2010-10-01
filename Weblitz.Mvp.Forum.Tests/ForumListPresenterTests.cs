using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using Weblitz.Mvp.Forum.Core;
using Weblitz.Mvp.Forum.Core.Models;
using Weblitz.Mvp.Forum.Core.Presenters;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Tests
{
    [TestFixture]
    public class ForumListPresenterTests
    {
        private MockRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new MockRepository();
        }

        [Test]
        public void ShouldShowEmptyForumListOnLoadWithNoData()
        {
            var view = _repository.DynamicMock<IForumListView>();
            var provider = _repository.DynamicMock<IForumProvider>();
            var loader = default(IEventRaiser);
            var data = default(IEnumerable<IForumDisplay>);
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(false);
                                             Expect.Call(() => view.Forums = data);
                                             Expect.Call(view.DataBind);
                                             SetupResult.For(view.Forums).Return(data);
                                         }).
                Verify(() =>
                           {
                               new ForumListPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               Assert.IsNull(data);
                               Assert.AreEqual(data, view.Forums);
                           });
        }

        [Test]
        public void ShouldShowForumListOnLoadWithData()
        {
            var view = _repository.DynamicMock<IForumListView>();
            var provider = _repository.DynamicMock<IForumProvider>();
            var loader = default(IEventRaiser);
            var data = new List<IForumDisplay> {new ForumDisplay {Name = "First Feature Forum"}};
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(false);
                                             Expect.Call(provider.List()).Return(data);
                                             Expect.Call(() => view.Forums = data);
                                             Expect.Call(view.DataBind);
                                             SetupResult.For(view.Forums).Return(data);
                                         }).
                Verify(() =>
                           {
                               new ForumListPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               Assert.IsNotNull(data);
                               Assert.AreEqual(data.Count, view.Forums.ToList().Count);
                           });
        }

        [Test]
        public void ShouldGoToForumFormOnNew()
        {
            var view = _repository.DynamicMock<IForumListView>();
            var provider = _repository.DynamicMock<IForumProvider>();
            var loader = default(IEventRaiser);
            var newer = default(IEventRaiser);
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             view.New += null;
                                             newer = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(true);
                                             Expect.Call(view.GoToForumForm);
                                         }).
                Verify(() =>
                           {
                               new ForumListPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               newer.Raise(null, new EventArgs());
                           });
        }

        [Test]
        public void ShouldGoToForumItemOnShow()
        {
            var view = _repository.DynamicMock<IForumListView>();
            var provider = _repository.DynamicMock<IForumProvider>();
            var loader = default(IEventRaiser);
            var shower = default(IEventRaiser);
            var data = new ForumDisplay {Id = 123};
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             view.Show += null;
                                             shower = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(true);
                                             Expect.Call(() => view.GoToForumItem(data.Id));
                                         }).
                Verify(() =>
                           {
                               new ForumListPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               shower.Raise(null, new IdEventArgs {Id = data.Id});
                           });
        }
    }
}