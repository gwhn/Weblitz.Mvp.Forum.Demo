using System.Collections.Generic;
using NUnit.Framework;
using Weblitz.Mvp.Forum.Core.Mappers;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Tests.Mappers
{
    [TestFixture]
    public class ForumMapperTests
    {
        [Test]
        public void ShouldMapForumEntityToDisplay()
        {
            // Arrange
            var data = new Core.Models.Forum
                           {
                               Id = 1423,
                               Name = "ToDisplay name",
                           };
            data.Topics = new List<ITopic>
                              {
                                  new Topic
                                      {
                                          Id = 1434,
                                          Forum = data,
                                          Sticky = true,
                                          Title = "ToDisplay title"
                                      }
                              };

            // Act
            var display = new ForumMapper().ToDisplay(data);
            // Assert
            Assert.AreEqual(data.Id, display.Id);
            Assert.AreEqual(data.Name, display.Name);
            Assert.AreEqual(data.Topics.Count, display.Topics.Count);
            Assert.IsNotNull(data.Topics[0]);
            Assert.IsNotNull(display.Topics[0]);
            Assert.AreEqual(data.Topics[0].Id, display.Topics[0].Id);
            Assert.AreEqual(data.Topics[0].Sticky, display.Topics[0].Sticky);
            Assert.AreEqual(data.Topics[0].Title, display.Topics[0].Title);
        }

        [Test]
        public void ShouldMapForumEntityFromInput()
        {
            // Arrange
            var input = new ForumInput {Id = 1423, Name = "FromInput name"};
            // Act
            var data = new ForumMapper().FromInput(input);
            // Assert
            Assert.AreEqual(input.Id, data.Id);
            Assert.AreEqual(input.Name, data.Name);
        }

        [Test]
        public void ShouldMapForumEntityToInput()
        {
            // Arrange
            var data = new Core.Models.Forum {Id = 4132, Name = "ToInput name"};
            // Act
            var input = new ForumMapper().ToInput(data);
            // Assert
            Assert.AreEqual(data.Id, input.Id);
            Assert.AreEqual(data.Name, input.Name);
        }
    }
}