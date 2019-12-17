using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WXRobot.Models
{
    [DataContract]
    public class RobotMessageImage : RobotMessage
    {
        public RobotMessageImage(string base64, string md5) : base("image")
        {
            this.Image = new RobotMessageImageItem(base64, md5);
        }

        [DataMember(Name = "image")]
        public RobotMessageImageItem Image { get; set; }
    }

    [DataContract]
    public class RobotMessageImageItem
    {
        public RobotMessageImageItem(string base64, string md5)
        {
            this.Base64 = base64;
            this.MD5 = md5;
        }
        [DataMember(Name = "base64")]
        public string Base64 { get; set; }
        [DataMember(Name = "md5")]
        public string MD5 { get; set; }
    }
}
