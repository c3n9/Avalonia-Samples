using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AvaloniaCRUD.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int RoleId { get; set; }
    [NotMapped]
    public virtual Role Role
    {
        get
        {
            using (var dbContext = new DBConnection())
            {
                return dbContext.Role.FirstOrDefault(x => x.Id == RoleId);
            }
        }
        // set
        // {
        //     RoleId = value.Id;
        // }
    }
}