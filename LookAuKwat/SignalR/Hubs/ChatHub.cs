//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using LookAuKwat.Models;
//using Microsoft.AspNet.SignalR;
//using Microsoft.AspNet.SignalR.Hubs;

//namespace LookAuKwat.SignalR.Hubs
//{
//    [HubName("chatHub")]
//    public class ChatHub : Hub
//    {
//        private IDal dal;
//        public ChatHub() : this(new Dal())
//        {

//        }

//        public ChatHub(IDal dalIoc)
//        {
//            dal = dalIoc;
//        }
//        #region---Data Members---
//        static List<ApplicationUser> ConnectedUsers = new List<ApplicationUser>();
//        static List<MessageDetails> CurrentMessage = new List<MessageDetails>();
//        #endregion

//        #region---Methods---

//        public void Connect(string UserName, string UserID)
//        {
//            var id = Context.ConnectionId;

//            if (ConnectedUsers.Count(x => x.ConnectionId == id) == 0)
//            {
//                ConnectedUsers.Add(new ApplicationUser { ConnectionId = id, UserName = UserName + "-" + UserID, Id = UserID });
//            }
//            ApplicationUser CurrentUser = ConnectedUsers.Where(u => u.ConnectionId == id).FirstOrDefault();
//            // send to caller           
//            Clients.Caller.onConnected(CurrentUser.Id, CurrentUser.UserName, ConnectedUsers, CurrentMessage, CurrentUser.Id);
//            // send to all except caller client           
//            Clients.AllExcept(CurrentUser.ConnectionId).onNewUserConnected(CurrentUser.Id, CurrentUser.UserName, CurrentUser.Id);
//        }

//        public void SendPrivateMessage(string toUserId, string message)
//        {
//            try
//            {
//                string fromconnectionid = Context.ConnectionId;
//                string strfromUserId = (ConnectedUsers.Where(u => u.ConnectionId == Context.ConnectionId).Select(u => u.Id).FirstOrDefault()).ToString();
//                //int _fromUserId = 0;
//                //int.TryParse(strfromUserId, out _fromUserId);
//                //int _toUserId = 0;
//                //int.TryParse(toUserId, out _toUserId);
//                List<ApplicationUser> FromUsers = ConnectedUsers.Where(u => u.Id == strfromUserId).ToList();
//                List<ApplicationUser> ToUsers = ConnectedUsers.Where(x => x.Id == toUserId).ToList();

//                if (FromUsers.Count != 0 && ToUsers.Count() != 0)
//                {
//                    foreach (var ToUser in ToUsers)
//                    {
//                        // send to                                                                                            //Chat Title
//                        Clients.Client(ToUser.ConnectionId).sendPrivateMessage(strfromUserId, FromUsers[0].UserName, FromUsers[0].UserName, message);
//                    }


//                    foreach (var FromUser in FromUsers)
//                    {
//                        // send to caller user                                                                                //Chat Title
//                        Clients.Client(FromUser.ConnectionId).sendPrivateMessage(toUserId, FromUsers[0].UserName, ToUsers[0].UserName, message);
//                    }
//                    // send to caller user
//                    //Clients.Caller.sendPrivateMessage(_toUserId.ToString(), FromUsers[0].UserName, message);
//                    //ChatDB.Instance.SaveChatHistory(_fromUserId, _toUserId, message);
//                    MessageDetails _MessageDeail = new MessageDetails { FromUserID = strfromUserId, FromUserName = FromUsers[0].UserName, ToUserID = toUserId, ToUserName = ToUsers[0].UserName, Message = message };
//                    AddMessageinCache(_MessageDeail);
//                }
//            }
//            catch { }
//        }
//        public void RequestLastMessage(string FromUserID, string ToUserID)
//        {
//            List<MessageDetails> CurrentChatMessages = (from u in CurrentMessage where ((u.FromUserID == FromUserID && u.ToUserID == ToUserID) || (u.FromUserID == ToUserID && u.ToUserID == FromUserID)) select u).ToList();
//            //send to caller user
//            Clients.Caller.GetLastMessages(ToUserID, CurrentChatMessages);
//        }

//        public void SendUserTypingRequest(string toUserId)
//        {
//            string strfromUserId = ConnectedUsers.Where(u => u.ConnectionId == Context.ConnectionId).Select(u => u.Id).FirstOrDefault();

//            //int _toUserId = 0;
//            //int.TryParse(toUserId, out _toUserId);
//            List<ApplicationUser> ToUsers = ConnectedUsers.Where(x => x.Id == toUserId).ToList();

//            foreach (var ToUser in ToUsers)
//            {
//                // send to                                                                                            
//                Clients.Client(ToUser.ConnectionId).ReceiveTypingRequest(strfromUserId);
//            }
//        }

//        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
//        {
//            var item = ConnectedUsers.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
//            if (item != null)
//            {
//                ConnectedUsers.Remove(item);
//                if (ConnectedUsers.Where(u => u.Id == item.Id).Count() == 0)
//                {
//                    var id = item.Id;
//                    Clients.All.onUserDisconnected(id, item.UserName);
//                }
//            }
//            return base.OnDisconnected(stopCalled);
//        }
//        public void Send(string name, string message)
//        {
//            var id = Context.ConnectionId;
//            Clients.All.addNewMessageToPage(name, message);
//        }
//        #endregion

//        #region---private Messages---
//        private void AddMessageinCache(MessageDetails _MessageDetail)
//        {
//            CurrentMessage.Add(_MessageDetail);
//            if (CurrentMessage.Count > 100)
//                CurrentMessage.RemoveAt(0);
//        }
//        #endregion
//    }
//}