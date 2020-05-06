using System;

namespace Domain
{
    public class MessageEntity : StorageEntity
    {
        /// <summary>
        /// Системное имя пользователя
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Текст сообщения
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Момент отправки
        /// </summary>
        public DateTime Time { get; set; }
    }
}
