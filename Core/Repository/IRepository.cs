
namespace Core.Repository
{
    public interface IRepository<TEntity>
    {
        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
