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
    public class ForumItemPresenterTests
    {
        private MockRepository _repository;

        [SetUp]
        public void SetUp()
        {
            _repository = new MockRepository();
        }

        [Test]
        public void ShouldShowForumOnLoadWithId()
        {
            var view = _repository.DynamicMock<IForumItemView>();
            var provider = _repository.DynamicMock<IForumProvider>();
            var loader = default(IEventRaiser);
            var id = 123;
            var data = new ForumDisplay{ Id = id, Name = "Forum name"};
            With.Mocks(_repository).
                ExpectingInSameOrder(() =>
                                         {
                                             view.Load += null;
                                             loader = LastCall.IgnoreArguments().GetEventRaiser();
                                             Expect.Call(view.IsPostBack).Return(false);
                                             Expect.Call(view.CurrentId).Return(id);
                                             Expect.Call(provider.Get(id)).Return(data);
                                             Expect.Call(view.Forum = data);
                                             SetupResult.For(view.Forum).Return(data);
                                         }).
                Verify(() =>
                           {
                               new ForumItemPresenter(view, provider);
                               loader.Raise(null, new EventArgs());
                               Assert.IsNotNull(view.Forum);
                               Assert.AreEqual(id, view.Forum.Id);
                           });
        }

    }
}