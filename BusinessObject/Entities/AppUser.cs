using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.Entities
{
    public class AppUser: IdentityUser
    {
        public AppUser()
        {
            Messages = new HashSet<Message>();
        }
        //1 --* appuser|| message
        public virtual ICollection<Message> Messages { get; set; }


    }
}
