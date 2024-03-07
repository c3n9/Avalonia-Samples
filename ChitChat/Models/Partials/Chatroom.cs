using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChat.Models
{
    public partial class Chatroom
    {
        public string LastChatMessage
        {
            get
            {
                using(DBConnection db = new DBConnection())
                {
                    var message = db.ChatMessage.Where(x => x.ChatroomId == this.Id).ToList().LastOrDefault();
                    if (message == null)
                    {
                        return string.Empty;
                    }
                    return message.Message.Substring(0,10) + "...";
                }
                
            }
        }
    }
}
