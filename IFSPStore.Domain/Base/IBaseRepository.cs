namespace IFSPStore.Domain.Base
{
    public interface IbaseRepository<TEntity>
        where TEntity : IBaseEntity
    {
        void ClearChangeTracker();

        void AtachObject(object obj);

        void Insert(TEntity entity);

        void Uptade(TEntity entity);

        void Delete(object id);

        IList<TEntity>Select(IList<string>? includes = null);

        TEntity Select(object id, IList <string>? includes = null);
    }
}
