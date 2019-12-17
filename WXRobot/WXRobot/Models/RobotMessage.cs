using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WXRobot.Models
{
    [DataContract]
    public abstract class RobotMessage
    {
        protected RobotMessage(string msgtype)
        {
            this.MessageType = msgtype;
        }
        [DataMember(Name = "msgtype")]
        public string MessageType { get; }
    }
}
