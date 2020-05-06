using Domain;
using System;

namespace Application.Abstractions
{
    public interface IUoW: IDisposable
    {
        IRepository<MessageEntity> Messages { get; set; }
        void Save();
    }
}
