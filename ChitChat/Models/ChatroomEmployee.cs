using System;
using System.Collections.Generic;

namespace ChitChat.Models;

public partial class ChatroomEmployee
{
    public long Id { get; set; }

    public long EmployeeId { get; set; }

    public long ChatroomId { get; set; }

    public virtual Chatroom Chatroom { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
