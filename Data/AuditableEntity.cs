using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleaningServiceAPI.Data
{
  public abstract class AuditableEntity
  {
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? UpdatedAt { get; set; }

    public DateTime? DeletedAt { get; set; }

    public bool IsDeleted { get; set; } = false;
  }
  // private static LambdaExpression BuildIsDeletedFilter(Type entityType)
  // {
  //     var parameter = Expression.Parameter(entityType, "e");
  //     var prop = Expression.Property(parameter, nameof(AuditableEntity.IsDeleted));
  //     var condition = Expression.Equal(prop, Expression.Constant(false));
  //     var lambda = Expression.Lambda(condition, parameter);
  //     return lambda;
  // }
// xq
}