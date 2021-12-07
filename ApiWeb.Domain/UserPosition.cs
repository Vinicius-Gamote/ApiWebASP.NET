using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Domain
{
    public class UserPosition
    {
        public int PositionId { get; set; }

        public Position Position { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
