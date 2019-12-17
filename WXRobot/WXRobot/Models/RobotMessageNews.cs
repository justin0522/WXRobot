using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WXRobot.Models
{
    [DataContract]
    public class RobotMessageNews : RobotMessage
    {
        public RobotMessageNews(string title, string url) : base("news")
        {
            var article = new RobotMessageNewsItem(title, url);
            this.Articles = new RobotMessageNewsArticles();
            this.Articles.Items = new List<RobotMessageNewsItem>();
            this.Articles.Items.Add(article);
        }

        [DataMember(Name = "news")]
        public RobotMessageNewsArticles Articles { get; set; }
    }

    [DataContract]
    public class RobotMessageNewsArticles
    {
        [DataMember(Name = "articles")]
        public List<RobotMessageNewsItem> Items { get; set; }
    }

    [DataContract]
    public class RobotMessageNewsItem
    {
        public RobotMessageNewsItem(string title, string url)
        {
            this.Title = title;
            this.Url = url;
        }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "url")]
        public string Url { get; set; }

        [DataMember(Name = "picurl")]
        public string PictureUrl { get; set; }
    }
}
