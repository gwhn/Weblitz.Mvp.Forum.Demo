using NUnit.Framework;
using Weblitz.Mvp.Forum.Core.Mappers;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Tests.Mappers
{
    [TestFixture]
    public class TopicMapperTests
    {
        [Test]
        public void ShouldMapTopicEntityToDisplay()
        {
            // Arrange
            var data = new Topic {Id = 1423, Forum = new Core.Models.Forum {Id = 1412}, Title = "ToDisplay name"};
            // Act
            var display = new TopicMapper().ToDisplay(data);
            // Assert
            Assert.AreEqual(data.Id, display.Id);
            Assert.AreEqual(data.Title, display.Title);
        }

        [Test]
        public void ShouldMapTopicEntityFromInput()
        {
            // Arrange
            var input = new TopicInput {Id = 1423, Title = "FromInput name"};
            // Act
            var data = new TopicMapper().FromInput(input);
            // Assert
            Assert.AreEqual(input.Id, data.Id);
            Assert.AreEqual(input.Title, data.Title);
        }

        [Test]
        public void ShouldMapTopicEntityToInput()
        {
            // Arrange
            var data = new Topic {Id = 4132, Forum = new Core.Models.Forum {Id = 1422}, Title = "ToInput name"};
            // Act
            var input = new TopicMapper().ToInput(data);
            // Assert
            Assert.AreEqual(data.Id, input.Id);
            Assert.AreEqual(data.Title, input.Title);
        }
    }
}