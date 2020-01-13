using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using WXRobot.Models;

namespace WXRobot
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = ConfigurationManager.AppSettings.Get("url");
            string textMessage = ConfigurationManager.AppSettings.Get("message");
            string imagePath = ConfigurationManager.AppSettings.Get("imagepath");
            string mentionedList = ConfigurationManager.AppSettings.Get("mentionedlist");
            List<string> mentions = new List<string>();
            if (!string.IsNullOrEmpty(mentionedList))
            {
                var array = mentionedList.Split(';', ',');
                foreach (var item in array)
                {
                    mentions.Add(item);
                }
            }
            var client = new MyHttpClient();

            if (!string.IsNullOrEmpty(textMessage))
            {
                client.Send(url, ProcessTextMessage(textMessage, false, mentions));
            }

            if (!string.IsNullOrEmpty(imagePath) && File.Exists(imagePath))
            {
                client.Send(url, ProcessImageMessage(imagePath));
            }

            client.Send(url, ProcessNewsMessage());
        }



        static RobotMessage ProcessTextMessage(string content, bool isAtAll, List<string> list)
        {
            var message = new RobotMessageText(content);
            if (isAtAll)
            {
                message.Text.MentionedList = new List<string>
                {
                    "@all"
                };
            }
            else
            {
                message.Text.MentionedList = list;
            }
            return message;
        }

        static RobotMessage ProcessImageMessage(string imagePath)
        {
            FileStream fs = File.OpenRead(imagePath);
            byte[] array = new byte[fs.Length];
            fs.Read(array, 0, (int)fs.Length);
            fs.Seek(0, SeekOrigin.Begin);
            MD5 md5Provider = new MD5CryptoServiceProvider();
            byte[] retVal = md5Provider.ComputeHash(fs);
            fs.Close();
            string content = Convert.ToBase64String(array);
            var md5 = BitConverter.ToString(retVal).Replace("-", string.Empty).ToLower();

            var message = new RobotMessageImage(content, md5);
            return message;
        }

        static RobotMessage ProcessNewsMessage()
        {
            var message = new RobotMessageNews("baidu", "https://www.baidu.com");
            var item = message.Articles.Items[0];
            item.Description = "www.baidu.com";
            item.PictureUrl = "https://www.baidu.com/img/baidu_jgylogo3.gif";
            return message;
        }
    }
}
