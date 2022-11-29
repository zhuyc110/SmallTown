namespace SmallTown.Entity
{
    public interface IEntityManager
    {
        IReadOnlyCollection<IEntity> Entities { get; }
    }
}