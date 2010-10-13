using System;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Mappers
{
    public class TopicMapper : IMapper<Topic, ITopicDisplay, ITopicInput>
    {
        public ITopicDisplay ToDisplay(Topic entity)
        {
            return new TopicDisplay
                       {
                           Id = entity.Id,
                           ForumId = entity.Forum.Id,
                           Sticky = entity.Sticky,
                           Title = entity.Title,
                           Body = entity.Body
                       };
        }

        public Topic FromInput(ITopicInput input)
        {
            return new Topic
                       {
                           Id = input.Id,
                           Forum = new Models.Forum {Id = input.ForumId},
                           Sticky = input.Sticky,
                           Title = input.Title,
                           Body = input.Body
                       };
        }

        public ITopicInput ToInput(Topic entity)
        {
            return new TopicInput
                       {
                           Id = entity.Id,
                           ForumId = entity.Forum.Id,
                           Sticky = entity.Sticky,
                           Title = entity.Title,
                           Body = entity.Body
                       };
        }
    }
}