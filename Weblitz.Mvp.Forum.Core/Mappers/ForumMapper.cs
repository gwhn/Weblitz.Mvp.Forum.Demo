using System;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Mappers
{
    public class ForumMapper : IMapper<IForum, IForumDisplay, IForumInput>
    {
        public IForumDisplay ToDisplay(IForum entity)
        {
            return new ForumDisplay {Id = entity.Id, Name = entity.Name};
        }

        public IForum FromInput(IForumInput input)
        {
            return new Models.Forum {Id = input.Id, Name = input.Name};
        }

        public IForumInput ToInput(IForum entity)
        {
            return new ForumInput {Id = entity.Id, Name = entity.Name};
        }
    }
}