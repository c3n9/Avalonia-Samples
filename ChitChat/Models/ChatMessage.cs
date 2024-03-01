using System;
using System.Collections.Generic;

namespace ChitChat.Models;

public partial class ChatMessage
{
    public long Id { get; set; }

    public long SenderId { get; set; }

    public DateOnly Date { get; set; }

    public string Message { get; set; } = null!;

    public virtual Employee Sender { get; set; } = null!;
}
