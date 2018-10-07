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
            VerifyIfPageExists(description.numPage, pagedResult.AllItemsCount);
            return pagedResult;
        }
        public static PagedResult<T> Page<T>(this IQueryable<T> list,int page,int pageSize)
        {

            var pagedResult = new PagedResult<T>
            {
                AllItemsCount = list.Count(),
                result = list.Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };
            VerifyIfPageExists(page, pagedResult.AllItemsCount);
            return pagedResult;
        }

        private static void VerifyIfPageExists(int page,long Count)
        {
            var pageDoesntExists = (page - 1) * 10 >= Count && page != 1;
            if (pageDoesntExists || page < 1)
                throw new ArgumentOutOfRangeException(nameof(page));
        }
    }
}
