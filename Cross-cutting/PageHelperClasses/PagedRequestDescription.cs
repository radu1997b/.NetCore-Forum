using System;
using System.Collections.Generic;
using System.Text;

namespace Cross_cutting.PageHelperClasses
{
    public class PagedRequestDescription
    {
        public int numPage { get; set; }
        public int pageSize { get; set; }
        public string searchKeyword { get; set; }
        public string columnToSearch { get; set; }
        public string columnToSort { get; set; }
        public string order { get; set; }
    }
}
