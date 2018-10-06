using Cross_cutting.Interfaces;
using Cross_cutting.PageHelperClasses;
using Forum.BLL.DataTransferObjects.Topic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Forum.BLL.Interfaces
{
    public interface ITopicService : IScopedService
    {
        PagedResult<TopicDTO> GetTopicsPage(PagedRequestDescription pagedRequestDescription);
        void CreateTopic(string TopicName);
        void Update(TopicDTO topic);
        void Delete(long id);
        IList<TopicListItemDTO> GetAllTopics();
        TopicInfoDTO GetTopicInfo(long Id);
    }
}
