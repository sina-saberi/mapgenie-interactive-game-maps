using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Domain.Entities.User
{
    public class User : IdentityUser
    {
        public virtual ICollection<UserLocation>? UserLocations { get; set; }
    }
}
