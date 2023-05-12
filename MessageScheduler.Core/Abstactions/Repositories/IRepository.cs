using MessageScheduler.Core.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MessageScheduler.Core.Abstactions.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        DbSet<T> Table { get; }
    }
}
