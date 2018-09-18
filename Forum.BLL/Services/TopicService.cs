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

namespace Forum.BLL.Services
{
    public class TopicService : ITopicService
    {
        private IRepository<Topic> _repository;
        private IMapper _mapper;
        public TopicService(IRepository<Topic> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public IEnumerable<TopicDTO> GetTopicsPage(int numOfPage, int pageSize, string searchKeyword, string columnToSort, string order)
        {
            if (searchKeyword == null)
                searchKeyword = "";
            var topics = _repository.GetAll().Where(p => p.TopicName.StartsWith(searchKeyword));
            if (order.Equals("asc", StringComparison.InvariantCultureIgnoreCase))
            {
                if (columnToSort == "NumberOfRooms")
                    topics = topics.OrderBy(p => p.Rooms.Count());
                else
                    topics = topics.OrderBy(p => p.GetType().GetProperty(columnToSort).GetValue(p));
            }
            else
            {
                if (columnToSort == "NumberOfRooms")
                    topics = topics.OrderByDescending(p => p.Rooms.Count());
                else
                    topics = topics.OrderByDescending(p => p.GetType().GetProperty(columnToSort).GetValue(p));
            }
            topics = topics.Page(numOfPage, pageSize);
            IEnumerable<TopicDTO> result = _mapper.Map<IEnumerable<Topic>, IEnumerable<TopicDTO>>(topics);
            return result;
        }
        public void CreateTopic(TopicDTO topic)
        {
            var newTopic = _mapper.Map<TopicDTO, Topic>(topic);
            _repository.Add(newTopic);
        }
        public void Update(TopicDTO topic)
        {
            var newTopic = _mapper.Map<TopicDTO, Topic>(topic);
            _repository.Update(newTopic);
        }
        public void Delete(long id)
        {
            var topic = _repository.GetAll().Where(p => p.Id == id).FirstOrDefault();
            if (topic != null)
                _repository.Delete(topic);
        }
        public long GetNumberOfTopics()
        {
            return _repository.GetAll().Count();
        }
    }
}
