using System;
using System.Collections.Generic;

namespace ChitChat.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int DepartmentId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual Department Department { get; set; } = null!;

    public virtual ICollection<EmployeeChatroom> EmployeeChatrooms { get; set; } = new List<EmployeeChatroom>();
}
