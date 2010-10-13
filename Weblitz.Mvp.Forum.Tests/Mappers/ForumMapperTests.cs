using System.Collections.ObjectModel;
using System.Data.Linq;
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
            // Act
            var display = new ForumMapper().ToDisplay(data);
            // Assert
            Assert.AreEqual(data.Id, display.Id);
            Assert.AreEqual(data.Name, display.Name);
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