using System.Collections.Generic;

namespace Weblitz.Mvp.Forum.Core.Models
{
    public interface IForumDisplay
    {
        int Id { get; }
        string Name { get; }
        IList<ITopicDisplay> Topics { get; }
    }
}