using System.Collections.Generic;
using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Providers
{
    public interface IForumProvider
    {
        IEnumerable<IForumDisplay> List();
        int Create(IForumInput forum);
        IForumDisplay Get(int id);
        bool Update(IForumInput forum);
    }
}