using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    public class JSON
    {
        public string message_type;
        private string message_ID;
        private string sender;
        private string subject;
        private string message;

        public string Message_ID
        {
            get
            {
                return message_ID;
            }
            set
            {
                message_ID = value;
            }
        }

        public string Message_type
        {
            get
            {
                return message_type;
            }
            set
            {
                message_type = value;
            }
        }

        public string Sender
        {
            get
            {
                return sender;
            }
            set
            {
                sender = value;
            }
        }

        public string Subject
        {
            get
            {
                return subject;
            }
            set
            {
                subject = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }
            set
            {
                message = value;
            }
        }
    }
}
