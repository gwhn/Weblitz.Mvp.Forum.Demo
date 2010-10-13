using Weblitz.Mvp.Forum.Core.Models;

namespace Weblitz.Mvp.Forum.Core.Mappers
{
    public interface IMapper<TEntity, out TDisplay, TInput> where TEntity : IEntity
    {
        TDisplay ToDisplay(TEntity entity);
        TEntity FromInput(TInput input);
        TInput ToInput(TEntity entity);
    }
}