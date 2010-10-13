using System;
using NUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Interfaces;
using Weblitz.Mvp.Forum.Core;
using Weblitz.Mvp.Forum.Core.Mappers;
using Weblitz.Mvp.Forum.Core.Models;
using Weblitz.Mvp.Forum.Core.Presenters;
using Weblitz.Mvp.Forum.Core.Providers;
using Weblitz.Mvp.Forum.Core.Views;

namespace Weblitz.Mvp.Forum.Tests.Presenters
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
            var id = 0;
            var data = new ForumInput();
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(false);
                                             Expect.Call(view.CurrentId).Return(id).Repeat.Any();
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
        public void ShouldGoToShowForumOnCreateWithNoId()
        {
            var view = _repository.DynamicMock<IForumFormView>();
            var provider = _repository.DynamicMock<IForumProvider>();
            var loader = default(IEventRaiser);
            var creator = default(IEventRaiser);
            var input = new ForumInput {Name = "New Forum"};
            var data = new ForumMapper().FromInput(input);
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
                                             Expect.Call(view.Forum).Return(input);
                                             Expect.Call(provider.Create(data)).IgnoreArguments().Return(newId);
                                             Expect.Call(() => view.GoToShowForum(newId));
                                         }).
                Verify(() =>
                           {
                               new ForumFormPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               creator.Raise(null, new EventArgs());
                           });
        }

        [Test]
        public void ShouldShowPopulatedForumFormOnLoadWithId()
        {
            var view = _repository.DynamicMock<IForumFormView>();
            var provider = _repository.DynamicMock<IForumProvider>();
            var loader = default(IEventRaiser);
            var id = 1423;
            var data = new Core.Models.Forum { Id = id, Name = "Populated Forum" };
            var input = new ForumMapper().ToInput(data);
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(false);
                                             Expect.Call(view.CurrentId).Return(id).Repeat.Any();
                                             Expect.Call(provider.Get(id)).Return(data);
                                             Expect.Call(view.Forum = input);
                                             LastCall.IgnoreArguments();
                                             SetupResult.For(view.Forum).Return(input);
                                         }).
                Verify(() =>
                           {
                               new ForumFormPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               Assert.IsNotNull(view.Forum);
                               Assert.AreEqual(data.Id, view.CurrentId);
                               Assert.AreEqual(input.Name, view.Forum.Name);
                           });
        }

        [Test]
        public void ShouldGoToShowForumOnUpdateWithId()
        {
            var view = _repository.DynamicMock<IForumFormView>();
            var provider = _repository.DynamicMock<IForumProvider>();
            var loader = default(IEventRaiser);
            var updater = default(IEventRaiser);
            var id = 3124;
            var data = new Core.Models.Forum {Id = id, Name = "Updated Forum"};
            var input = new ForumMapper().ToInput(data);
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             view.Update += null;
                                             updater = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(true);
                                             Expect.Call(view.IsValid).Return(true);
                                             Expect.Call(view.Forum).Return(input);
                                             Expect.Call(provider.Update(data)).IgnoreArguments().Return(true);
                                             Expect.Call(() => view.GoToShowForum(id));
                                         }).
                Verify(() =>
                           {
                               new ForumFormPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               updater.Raise(null, new IdEventArgs {Id = id});
                           });
        }
    }
}