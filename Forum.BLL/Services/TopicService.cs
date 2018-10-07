using Forum.BLL.Interfaces;
using System.Collections.Generic;
using Forum.DAL.Domain;
using Forum.DAL.Repository;
using Forum.BLL.DataTransferObjects.Topic;
using AutoMapper;
using Cross_cutting.PageHelperClasses;


namespace Forum.BLL.Services
{
    public class TopicService : ITopicService
    {
        private ITopicRepository _repository;
        private IMapper _mapper;
        public TopicService(ITopicRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public PagedResult<TopicDTO> GetTopicsPage(PagedRequestDescription pagedRequestDescription)
        {
            var getTopicsPaginated = _repository.GetTopicsPaged(pagedRequestDescription);
            var result = new PagedResult<TopicDTO>
            {
                AllItemsCount = getTopicsPaginated.AllItemsCount,
                result = _mapper.Map<IList<Topic>, IList<TopicDTO>>(getTopicsPaginated.result)
            };
            return result;
        }
        public void CreateTopic(string TopicName)
        {
            var topic = new Topic
            {
                TopicName = TopicName
            };
            _repository.Add(topic);
            _repository.Save();
        }
        public void Update(TopicDTO topic)
        {
            var oldTopic = _repository.GetById(topic.Id);
            if (oldTopic == null)
                throw new KeyNotFoundException();
            _mapper.Map(topic, oldTopic);
            _repository.Update(oldTopic);
            _repository.Save();
        }
        public void Delete(long id)
        {
            var topic = _repository.GetById(id);
            if (topic != null)
            {
                _repository.Delete(topic);
                _repository.Save();
                return;
            }
            throw new KeyNotFoundException();
        }
        public IList<TopicListItemDTO> GetAllTopics()
        {
            var allTopicsDomain = _repository.GetAllTopics();
            var result = _mapper.Map<IList<Topic>, IList<TopicListItemDTO>>(allTopicsDomain);
            return result;
        }
        public TopicInfoDTO GetTopicInfo(long Id)
        {
            var topicDomain = _repository.GetById(Id);
            var result = _mapper.Map<Topic, TopicInfoDTO>(topicDomain);
            return result;
        }

    }
}
