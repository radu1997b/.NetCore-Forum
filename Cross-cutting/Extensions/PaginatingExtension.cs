using Cross_cutting.PageHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cross_cutting.Extensions
{
    public static class PaginatingExtension
    {
        public static PagedResult<T> Page<T>(this IQueryable<T> list,PagedRequestDescription description)
        {
            if (description.searchKeyword == null)
                description.searchKeyword = "";
            var query = list.Where(p => p.GetType().GetProperty(description.columnToSearch).GetValue(p).ToString().StartsWith(description.searchKeyword));
            if (description.order.Equals("asc", StringComparison.InvariantCultureIgnoreCase))
                query = query.OrderBy(p => p.GetType().GetProperty(description.columnToSort).GetValue(p));
            else
                query = query.OrderByDescending(p => p.GetType().GetProperty(description.columnToSort).GetValue(p));
            var pagedResult = query.Page(description.numPage, description.pageSize);
            return pagedResult;
        }
        public static PagedResult<T> Page<T>(this IQueryable<T> list,int page,int pageSize)
        {

            var pagedResult = new PagedResult<T>
            {
                AllItemsCount = list.Count(),
                result = list.Skip((page - 1) * pageSize).Take(pageSize).ToList()
            };
            pagedResult.NumberOfPages = GetNumberOfPages(pagedResult.AllItemsCount,pageSize);
            VerifyIfPageExists(page, pagedResult.AllItemsCount);
            return pagedResult;
        }

        private static void VerifyIfPageExists(int page,long Count)
        {
            var pageDoesntExists = (page - 1) * 10 >= Count && page != 1;
            if (pageDoesntExists || page < 1)
                throw new ArgumentOutOfRangeException(nameof(page));
        }
        private static int GetNumberOfPages(int NumberOfPosts,int pageSize)
        {
            if (NumberOfPosts % pageSize == 0)
                return NumberOfPosts / pageSize;
            return NumberOfPosts / pageSize + 1;
        }
    }
}
