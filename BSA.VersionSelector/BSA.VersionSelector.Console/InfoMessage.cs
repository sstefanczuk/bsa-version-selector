using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSA.VersionSelector.ConsoleApp
{
    public class InfoMessage
    {
        private string Message { get; set; }
        public MessageType Type { get; private set; }

        public void SetInfo(string message)
        {
            Message = message;
            Type = MessageType.Info;
        }

        public void SetError(string message)
        {
            Message = message;
            Type = MessageType.Error;
        }

        public void Clear()
        {
            Message = null;
        }

        public override string ToString()
        {
            return Message;
        }

        public enum MessageType
        {
            Info,
            Error
        }
    }
}
