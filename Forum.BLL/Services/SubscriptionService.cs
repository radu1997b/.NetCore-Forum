using AutoMapper;
using Cross_cutting.Exceptions;
using Forum.BLL.DataTransferObjects.Subscriptions;
using Forum.BLL.Interfaces;
using Forum.DAL.Domain;
using Forum.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Forum.BLL.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private ISubscriptionsRepository _repository;
        private IMapper _mapper;
        public SubscriptionService(ISubscriptionsRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public bool GetSubscriptionStatusForUser(string UserId,long RoomId)
        {
            var subscription = _repository.GetById(UserId, RoomId);
            if (subscription == null)
                return false;
            return true;
        }

        public void Subscribe(SubscriptionsDTO subscription)
        {
            var subscriptionDomain = _mapper.Map<SubscriptionsDTO, UserRoom>(subscription);
            _repository.Add(subscriptionDomain);
            _repository.Save();
        }
        public void UnSubscribe(SubscriptionsDTO subscription)
        {
            var subscriptionDomain = _mapper.Map<SubscriptionsDTO, UserRoom>(subscription);
            _repository.Delete(subscriptionDomain);
            _repository.Save();
        }
    }
}
