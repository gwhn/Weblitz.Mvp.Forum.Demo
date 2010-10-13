namespace Weblitz.Mvp.Forum.Core.Models
{
    public interface IPost : IEntity
    {
        string Body { get; set; }
    }
}