using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using QimiaSchool.DataAccess.Exceptions;

namespace QimiaSchool.DataAccess.Repositories.Abstractions;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected QimiaSchoolDbContext DbContext { get; set; }
    private readonly DbSet<T> DbSet;

    protected RepositoryBase(QimiaSchoolDbContext dbContext)
    {
        DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        DbSet = dbContext.Set<T>();
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await DbSet.ToListAsync(cancellationToken);
    }

    public async Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
    {
        return await DbSet.Where(expression).ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var entity = await DbSet.FindAsync(id);

        if (entity == null)
        {
            throw new EntityNotFoundException<T>(id);
        }

        return entity;
    }

    public async Task CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        DbSet.Update(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(int id, CancellationToken cancellationToken)
    {
        var entity = await GetByIdAsync(id)
; // Await the GetByIdAsync method
        DbSet.Remove(entity);
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}