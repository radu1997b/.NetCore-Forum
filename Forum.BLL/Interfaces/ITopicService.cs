using Forum.BLL.DataTransferObjects.Topic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Forum.BLL.Interfaces
{
    public interface ITopicService
    {
        IEnumerable<TopicDTO> GetTopicsPage(int numOfPage, int pageSize,string searchKeyword,string columnToSort,string order);
        void CreateTopic(TopicDTO topic);
        void Update(TopicDTO topic);
        void Delete(long id);
        long GetNumberOfTopics();
    }
}
