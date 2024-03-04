using System;
using System.Collections.Generic;

namespace ChitChat.Models;

public partial class EmployeeChatroom
{
    public int Id { get; set; }

    public int EmployeeId { get; set; }

    public int ChatroomId { get; set; }

    public virtual Chatroom Chatroom { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;
}
