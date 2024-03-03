using Application.Models.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Helpers
{
    public class PersistenceHelpers
    {
        public static Expression<Func<TEntity, bool>> BuildLambdaPredicate<TEntity>(SearchData data)
        {
            var parameter = Expression.Parameter(typeof(TEntity), "entity");
            var likeMethod = typeof(DbFunctionsExtensions).GetMethod("Like", new[] { typeof(DbFunctions), typeof(string), typeof(string) });

            Expression body = null;
            foreach (var property in typeof(TEntity).GetProperties())
            {
                if (property.PropertyType != typeof(string) && !property.PropertyType.IsValueType)
                    continue;

                var propertyAccess = Expression.PropertyOrField(parameter, property.Name);
                var toStringCall = Expression.Call(propertyAccess, "ToString", Type.EmptyTypes);
                var likeCall = Expression.Call(null, likeMethod, Expression.Constant(EF.Functions), toStringCall, Expression.Constant($"%{data.SearchText}%"));

                body = body == null ? (Expression)likeCall : Expression.OrElse(body, likeCall);
            }

            var lambda = Expression.Lambda<Func<TEntity, bool>>(body, parameter);

            return lambda;
        }
    }
}
