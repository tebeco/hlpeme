
using Microsoft.AspNetCore.Identity;

namespace BaseConn.Api.Db.Models;

public class ApplicationUser : IdentityUser<int>
{
    public int ServiceId {get;set;}
}
