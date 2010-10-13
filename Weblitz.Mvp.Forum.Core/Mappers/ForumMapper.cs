using System.Linq;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Mappers
{
    public class ForumMapper : IMapper<Models.Forum, IForumDisplay, IForumInput>
    {
        public IForumDisplay ToDisplay(Models.Forum entity)
        {
            return new ForumDisplay
                       {
                           Id = entity.Id,
                           Name = entity.Name,
                           Topics =
                               entity.Topics == null
                                   ? null
                                   : entity.Topics.Select(topic => new TopicMapper().ToDisplay(topic)).ToList()
                       };
        }

        public Models.Forum FromInput(IForumInput input)
        {
            return new Models.Forum {Id = input.Id, Name = input.Name};
        }

        public IForumInput ToInput(Models.Forum entity)
        {
            return new ForumInput {Id = entity.Id, Name = entity.Name};
        }
    }
}