using System;
using System.Collections.Generic;

namespace ChitChat.Models;

public partial class Employee
{
    public long Id { get; set; }

    public string? Name { get; set; }

    public long? DepartmentId { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<ChatMessage> ChatMessages { get; set; } = new List<ChatMessage>();

    public virtual ICollection<ChatroomEmployee> ChatroomEmployees { get; set; } = new List<ChatroomEmployee>();

    public virtual Department? Department { get; set; }
}
