using System.Collections.Generic;

namespace Weblitz.Mvp.Forum.Core.Models
{
    public interface IForum : IEntity
    {
        string Name { get; set; }
        IList<ITopic> Topics { get; set; }
    }
}