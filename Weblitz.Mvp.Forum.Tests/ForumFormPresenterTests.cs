using System;
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
    public class ForumFormPresenterTests
    {
        private MockRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new MockRepository();
        }

        [Test]
        public void ShouldShowEmptyForumFormOnLoadWithNoId()
        {
            var view = _repository.DynamicMock<IForumFormView>();
            var provider = _repository.DynamicMock<IForumProvider>();
            var loader = default(IEventRaiser);
            var data = new ForumInput();
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(false);
                                             Expect.Call(view.Forum = data);
                                             LastCall.IgnoreArguments();
                                             SetupResult.For(view.Forum).Return(data);
                                         }).
                Verify(() =>
                           {
                               new ForumFormPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               Assert.IsNotNull(view.Forum);
                               Assert.AreEqual(data.Name, view.Forum.Name);
                           });
        }

        [Test]
        public void ShouldGoToShowForumOnCreateNewForum()
        {
            var view = _repository.DynamicMock<IForumFormView>();
            var provider = _repository.DynamicMock<IForumProvider>();
            var loader = default(IEventRaiser);
            var creator = default(IEventRaiser);
            var data = new ForumInput { Name = "New Forum"};
            var newId = 321;
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             view.Create += null;
                                             creator = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(true);
                                             Expect.Call(view.IsValid).Return(true);
                                             Expect.Call(view.Forum).Return(data);
                                             Expect.Call(provider.Create(data)).Return(newId);
                                             Expect.Call(() => view.GoToShowForum(newId));
                                         }).
                Verify(() =>
                           {
                               new ForumFormPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               creator.Raise(null, new EventArgs());
                           });
        }

    }
}