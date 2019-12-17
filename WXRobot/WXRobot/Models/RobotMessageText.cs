using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WXRobot.Models
{
    [DataContract]
    public class RobotMessageText : RobotMessage
    {
        public RobotMessageText(string content) : base("text")
        {
            Text = new RobotMessageTextItem(content);
        }

        [DataMember(Name = "text")]
        public RobotMessageTextItem Text { get; set; }
    }

    [DataContract]
    public class RobotMessageTextItem
    {
        public RobotMessageTextItem(string content)
        {
            this.Content = content;
        }

        [DataMember(Name = "content")]
        public string Content { get; set; }

        [DataMember(Name = "mentioned_list")]
        public List<string> MentionedList { get; set; }

        [DataMember(Name = "mentioned_mobile_list")]
        public List<string> MentionedMobileList { get; set; }
    }
}
