using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using Weblitz.Mvp.Forum.Core.Models;
using Weblitz.Mvp.Forum.Core.Presenters;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Tests
{
    [TestFixture]
    public class ForumPresenterTests
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
                               new ForumPresenter(view, provider);
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
            var data = new List<IForumDisplay> { new ForumDisplay { Name = "First Feature Forum" } };

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
                               new ForumPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               Assert.IsNotNull(data);
                               Assert.AreEqual(data.Count, view.Forums.ToList().Count);
                           });
        }

    }
}