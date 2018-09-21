using Cross_cutting.PageHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.DAL.Extensions
{
    static class PaginatingExtension
    {
        public static PagedResult<T> Page<T>(this IQueryable<T> list,PagedRequestDescription description)
        {
            if (description.searchKeyword == null)
                description.searchKeyword = "";
            var pagedResult = new PagedResult<T>
            {
                AllItemsCount = list.Count(),
                result = list
                    .Where(p => p.GetType().GetProperty(description.columnToSearch).GetValue(p).ToString().StartsWith(description.searchKeyword))
                    .OrderBy(p => p.GetType().GetProperty(description.columnToSort))
                    .Skip((description.numPage - 1) * description.pageSize)
                    .Take(description.pageSize)
                    .ToList()
            };
            return pagedResult;
        }

    }
}
