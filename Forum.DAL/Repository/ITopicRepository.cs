using Forum.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using Cross_cutting.PageHelperClasses;

namespace Forum.DAL.Repository
{
    public interface ITopicRepository : IRepository<Topic>
    {
        PagedResult<Topic> GetTopicsPaged(PagedRequestDescription pagedRequestDescription);
    }
}
