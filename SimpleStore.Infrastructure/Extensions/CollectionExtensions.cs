using System;
using System.Collections.Generic;
using System.Text;
using SimpleStore.DataAccess.Enums;
using SimpleStore.DataAccess.Helpers;

namespace SimpleStore.DataAccess.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddMessage(this List<Message<MessageType, string>> obj, MessageType type, string value)
        {
            obj.Add(new Message<MessageType, string>(type, value));
        }
    }
}