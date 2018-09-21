using Forum.BLL.Interfaces;
using System.Collections.Generic;
using System.Text;
using Forum.DAL.Domain;
using Forum.DAL.Repository;
using Forum.BLL.DataTransferObjects.Topic;
using Forum.BLL.Extensions;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System.Text.RegularExpressions;
using System;
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
            //TODO Move logic to extension method
            var getTopicsPaginated = _repository.GetTopicsPaged(pagedRequestDescription);
            var result = new PagedResult<TopicDTO>
            {
                AllItemsCount = getTopicsPaginated.AllItemsCount,
                result = _mapper.Map<ICollection<Topic>, ICollection<TopicDTO>>(getTopicsPaginated.result)
            };
            return result;
        }
        public void CreateTopic(TopicDTO topic)
        {
            var newTopic = _mapper.Map<TopicDTO, Topic>(topic);
            _repository.Add(newTopic);
            _repository.Save();
        }
        public void Update(TopicDTO topic)
        {
            var oldTopic = _repository.GetById(topic.Id);
            if (oldTopic == null)
                throw new Exception("Resource not found");
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
            throw new Exception("Resource not Found");
        }

    }
}
