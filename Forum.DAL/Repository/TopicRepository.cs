using Cross_cutting.Extensions;
using Cross_cutting.PageHelperClasses;
using Forum.DAL.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
        public IList<Topic> GetAllTopics()
        {
            return _context.Set<Topic>().ToList();
        }
    }
}
