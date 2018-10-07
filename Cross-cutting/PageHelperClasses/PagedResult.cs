using System;
using System.Collections.Generic;
using System.Text;

namespace Cross_cutting.PageHelperClasses
{
    public class PagedResult<T>
    {
        public int AllItemsCount { get; set; }
        public IList<T> result { get; set; }
        public int NumberOfPages { get; set; }
    }
}
