using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public class MessageDetails
    {
        public int Id { get; set; }
        public string FromUserID { get; set; }
        public string FromUserName { get; set; }
        public string ToUserID { get; set; }
        public string ToUserName { get; set; }
        public string Message { get; set; }
    }
}