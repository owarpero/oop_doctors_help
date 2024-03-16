using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DoctorsHelp.Infrastructure.Persistence.Repositories;

public abstract class RepositoryBase<TEntity, TModel> where TModel : class
{
    #pragma warning disable IDE0032
    private readonly DbContext _context;

    protected DbContext Context => _context;

    protected RepositoryBase(DbContext context)
    {
        this._context = context;
    }

    protected abstract DbSet<TModel> DbSet { get; }

    public void Add(TEntity entity)
    {
        TModel model = MapFrom(entity);
        DbSet.Add(model);
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        IEnumerable<TModel> models = entities.Select(MapFrom);
        DbSet.AddRange(models);
    }

    public void Update(TEntity entity)
    {
        EntityEntry<TModel> entry = GetEntry(entity);
        UpdateModel(entry.Entity, entity);

        entry.State = EntityState.Modified;
    }

    public void Remove(TEntity entity)
    {
        EntityEntry<TModel> entry = GetEntry(entity);
        entry.State = entry.State is EntityState.Added ? EntityState.Detached : EntityState.Deleted;
    }

    protected abstract TModel MapFrom(TEntity entity);

    protected abstract bool Equal(TEntity entity, TModel model);

    protected abstract void UpdateModel(TModel model, TEntity entity);

    private EntityEntry<TModel> GetEntry(TEntity entity)
    {
        TModel? existing = DbSet.Local.FirstOrDefault(model => Equal(entity, model));

        return existing is not null
            ? _context.Entry(existing)
            : DbSet.Attach(MapFrom(entity));
    }
}