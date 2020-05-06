using Application.Abstractions;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Application.Services
{
    public class MessagesService : IFindLastService<MessageEntity>
    {
        private readonly IUoWFactory _unitOfWorkFactory;

        public MessagesService(IUoWFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public MessageEntity Add(MessageEntity message)
        {
            using (var _unitOfWork = _unitOfWorkFactory.Create())
            {
                _unitOfWork.Messages.Insert(message);
                _unitOfWork.Save();
            }

            return message;
        }

        public void Delete(int id)
        {
            using (var _unitOfWork = _unitOfWorkFactory.Create())
            {
                _unitOfWork.Messages.Delete(id);
                _unitOfWork.Save();
            }
        }

        public MessageEntity Edit(MessageEntity message)
        {
            using (var _unitOfWork = _unitOfWorkFactory.Create())
            {
                _unitOfWork.Messages.Update(message);
                _unitOfWork.Save();
            }

            return message;
        }

        public MessageEntity Get(int id)
        {
            using (var _unitOfWork = _unitOfWorkFactory.Create())
            {
                return _unitOfWork.Messages.Get(id);
            }
        }

        public IEnumerable<MessageEntity> GetAll()
        {
            using (var _unitOfWork = _unitOfWorkFactory.Create())
            {
                return _unitOfWork.Messages.GetAll().ToList();
            }
        }

        public MessageEntity GetLast()
        {
            using (var _unitOfWork = _unitOfWorkFactory.Create())
            {
                return _unitOfWork.Messages.GetAll().Any() 
                            ? _unitOfWork.Messages.GetAll().OrderBy(x => x.Time).Last() 
                            : new MessageEntity { Text = string.Empty };
            }
        }
    }
}
