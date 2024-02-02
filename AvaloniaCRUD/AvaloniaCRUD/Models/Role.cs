using System.Collections;
using System.Collections.Generic;

namespace AvaloniaCRUD.Models;

public class Role
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<User> Users { get; set; }

}