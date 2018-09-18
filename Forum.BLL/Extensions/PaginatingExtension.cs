using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.BLL.Extensions
{
    static class PaginatingExtension
    {
        public static IQueryable<T> Page<T>(this IQueryable<T> list,int pageNumber = 1,int pageSize = 10)
        {
            return list.Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }
    }
}
