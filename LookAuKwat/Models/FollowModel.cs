using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LookAuKwat.Models
{
    public class FollowModel
    {
        public int id { get; set; }
        public string Follower_Email { get; set; }
        public string Follower_FirstName { get; set; }
        public ApplicationUser User { get; set; }
        public string Follower_Id { get; set; }
        public bool IsNotify_For_new_Followar { get; set; }
        public bool User_New_Announce_AlreadyNotifyTo_follower { get; set; }
        public DateTime followedDate { get; set; }
    }
}