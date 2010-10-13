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
    public class TopicFormPresenterTests
    {
        private MockRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new MockRepository();
        }

        [Test]
        public void ShouldShowEmptyTopicFormOnLoadWithNoId()
        {
            var view = _repository.DynamicMock<ITopicFormView>();
            var provider = _repository.DynamicMock<ITopicProvider>();
            var loader = default(IEventRaiser);
            var id = 0;
            var data = new TopicInput();
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(false);
                                             Expect.Call(view.CurrentId).Return(id).Repeat.Any();
                                             Expect.Call(view.Topic = data);
                                             LastCall.IgnoreArguments();
                                             SetupResult.For(view.Topic).Return(data);
                                         }).
                Verify(() =>
                           {
                               new TopicFormPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               Assert.IsNotNull(view.Topic);
                               Assert.AreEqual(data.Title, view.Topic.Title);
                           });
        }

        [Test]
        public void ShouldGoToShowTopicOnCreateWithNoId()
        {
            var view = _repository.DynamicMock<ITopicFormView>();
            var provider = _repository.DynamicMock<ITopicProvider>();
            var loader = default(IEventRaiser);
            var creator = default(IEventRaiser);
            var input = new TopicInput
                            {
                                ForumId = 1423,
                                Title = "New Topic",
                                Body = "New topic body",
                                Sticky = false
                            };
            var data = new TopicMapper().FromInput(input);
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
                                             Expect.Call(view.Topic).Return(input);
                                             Expect.Call(provider.Create(data)).IgnoreArguments().Return(newId);
                                             Expect.Call(() => view.GoToShowTopic(newId));
                                         }).
                Verify(() =>
                           {
                               new TopicFormPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               creator.Raise(null, new EventArgs());
                           });
        }

        [Test]
        public void ShouldShowPopulatedTopicFormOnLoadWithId()
        {
            var view = _repository.DynamicMock<ITopicFormView>();
            var provider = _repository.DynamicMock<ITopicProvider>();
            var loader = default(IEventRaiser);
            var id = 4122;
            var data = new Topic
                           {
                               Id = id,
                               Title = "Populated topic title",
                               Body = "Populated topic body",
                               Sticky = true,
                               Forum = new Core.Models.Forum
                                           {
                                               Id = 4132,
                                               Name = "Parent forum name"
                                           }
                           };
            var input = new TopicMapper().ToInput(data);
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(false);
                                             Expect.Call(view.CurrentId).Return(id).Repeat.Any();
                                             Expect.Call(provider.Get(id)).Return(data);
                                             Expect.Call(view.Topic = input);
                                             LastCall.IgnoreArguments();
                                             SetupResult.For(view.Topic).Return(input);
                                         }).
                Verify(() =>
                           {
                               new TopicFormPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               Assert.IsNotNull(view.Topic);
                               Assert.AreEqual(data.Id, view.CurrentId);
                               Assert.AreEqual(data.Title, view.Topic.Title);
                               Assert.AreEqual(data.Body, view.Topic.Body);
                               Assert.AreEqual(data.Sticky, view.Topic.Sticky);
                               Assert.AreEqual(data.Forum.Id, view.Topic.ForumId);
                           });
        }

        [Test]
        public void ShouldGoToShowTopicOnUpdateWithId()
        {
            var view = _repository.DynamicMock<ITopicFormView>();
            var provider = _repository.DynamicMock<ITopicProvider>();
            var loader = default(IEventRaiser);
            var updater = default(IEventRaiser);
            var id = 1423;
            var data = new Topic
                           {
                               Id = id,
                               Title = "Updated topic title",
                               Body = "updated topic body",
                               Forum = new Core.Models.Forum
                                           {
                                               Id = 4123,
                                               Name = "Parent forum name"
                                           }
                           };
            var input = new TopicMapper().ToInput(data);
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             view.Update += null;
                                             updater = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(true);
                                             Expect.Call(view.IsValid).Return(true);
                                             Expect.Call(view.Topic).Return(input);
                                             Expect.Call(provider.Update(data)).IgnoreArguments().Return(true);
                                             Expect.Call(() => view.GoToShowTopic(id));
                                         }).
                Verify(() =>
                           {
                               new TopicFormPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               updater.Raise(null, new IdEventArgs {Id = id});
                           });
        }
    }
}