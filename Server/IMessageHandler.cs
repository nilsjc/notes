using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server
{
    public interface IMessageHandler
    {
        public void PutMessageOnQueue(Message message, string queue);
        public Task<Message> GetMessageFromQueue(string queue);

    }
}