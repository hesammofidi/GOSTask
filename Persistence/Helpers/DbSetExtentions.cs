using Application.Models.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Helpers
{
    public static class DbSetExtentions
    {
        private const int Default_Page_Size = 10;
        private const int Max_Page_Size = 100;

        public static IQueryable<TEntity> Filter<TEntity>(
            this IQueryable<TEntity> query,
            string? filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return query;
            }
            return query.Where(filter);
        }

        public static IQueryable<TEntity> Sort<TEntity>(this IQueryable<TEntity> query, string? sort)
        {
            if (string.IsNullOrEmpty(sort))
            {
                return query;
            }
            return query.OrderBy(sort);
        }

        public static async Task<PagedList<TEntity>> PageAsync<TEntity>(
            this IQueryable<TEntity> query,
            int? pageSize,
            int? pageIndex
            )
        {
            if (pageSize.HasValue)
            {
                if (pageSize > Max_Page_Size)
                {
                    pageSize = Max_Page_Size;
                }
                if (pageSize <= 0)
                {
                    pageSize = Default_Page_Size;
                }
            }
            else
            {
                pageSize = Default_Page_Size;
            }
            if (pageIndex.HasValue)
            {
                if (pageIndex.Value <= 0)
                {
                    pageIndex = 1;
                }
                else
                {
                    pageIndex = pageIndex.Value;
                }
            }
            else
            {
                pageIndex = 1;
            }

            var items = await query.Skip((pageIndex!.Value - 1) * pageSize!.Value).Take(pageSize!.Value).ToListAsync();

            var totalRecordCount = await query.CountAsync();
            return new PagedList<TEntity>(items, pageSize.Value, pageIndex.Value, totalRecordCount);
        }
    }
}
