﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{
    public class MailModel
    {
        public MailModel()
        {
            MailTo = new List<string>();
        }
        public MailModel(List<string> mailTo, string mailFrom, string title = "", string body = "")
        {
            MailTo = mailTo;
            MailFrom = mailFrom;
            Title = title;
            Body = body;
        }
        public void SetMailTo(string emails)
        {
            var temp = emails.Split(';');
            MailTo.AddRange(temp);
            MailTo.Remove(string.Empty);
        }
        public List<string> MailTo { get; set; }
        public string MailFrom { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
