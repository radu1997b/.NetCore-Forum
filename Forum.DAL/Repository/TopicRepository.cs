using Cross_cutting.PageHelperClasses;
using Forum.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Forum.DAL.Extensions;

namespace Forum.DAL.Repository
{
    public class TopicRepository : Repository<Topic>,ITopicRepository
    {
        public TopicRepository(DbContext context) : base(context)
        { }

        public PagedResult<Topic> GetTopicsPaged(PagedRequestDescription pagedRequestDescription)
        {
            return _context.Set<Topic>().Page(pagedRequestDescription);
        }
    }
}
