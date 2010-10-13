using System;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Mappers
{
    public class TopicMapper : IMapper<ITopic, ITopicDisplay, ITopicInput>
    {
        public ITopicDisplay ToDisplay(ITopic entity)
        {
            return new TopicDisplay
                       {
                           Id = entity.Id,
                           ForumId = entity.Forum.Id,
                           Sticky = entity.Sticky,
                           Title = entity.Title
                       };
        }

        public ITopic FromInput(ITopicInput input)
        {
            return new Topic
                       {
                           Id = input.Id,
                           Forum = new Models.Forum {Id = input.ForumId},
                           Sticky = input.Sticky,
                           Title = input.Title
                       };
        }

        public ITopicInput ToInput(ITopic entity)
        {
            return new TopicInput
                       {
                           Id = entity.Id,
                           ForumId = entity.Forum.Id,
                           Sticky = entity.Sticky,
                           Title = entity.Title
                       };
        }
    }
}