using System;
using System.Collections.Generic;

namespace ChitChat.Models;

public partial class Chatroom
{
    public long Id { get; set; }

    public string Topic { get; set; } = null!;

    public virtual ICollection<ChatroomEmployee> ChatroomEmployees { get; set; } = new List<ChatroomEmployee>();
}
