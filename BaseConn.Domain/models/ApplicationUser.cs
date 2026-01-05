
using Microsoft.AspNetCore.Identity;

namespace BaseConn.Domain.models
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        public Guid ServiceId {get;set;}

        public virtual ICollection<Note> Notes { get; set; }

        public virtual ICollection<Problem> Problems { get; set; }
        public virtual ICollection<Problem> FounderProblems { get; set; }

        public Service service {get;set;}
        

    }
}