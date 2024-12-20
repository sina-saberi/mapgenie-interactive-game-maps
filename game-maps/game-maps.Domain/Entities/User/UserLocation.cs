using game_maps.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game_maps.Domain.Entities.User
{
    public class UserLocation : Entity
    {
        public string UserId { get; set; } = "";  // Change int to string
        public int LocationId { get; set; }
        public bool Checked { get; set; }
    }
}
