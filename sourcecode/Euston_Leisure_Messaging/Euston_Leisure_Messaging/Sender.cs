using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euston_Leisure_Messaging
{
    public class Sender : JSON
    {
        private bool email;
        private bool tweet;
        private bool sms;
        


        public bool Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public bool Tweet
        {
            get
            {
                return tweet;
            }
            set
            {
                tweet = value;
            }
        }

        public bool Sms
        {
            get
            {
                return sms;
            }
            set
            {
                sms = value;
            }
        }

        
    }
}
