using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Domain
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? Birthday { get; set; }

        public string UserIcon { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IEnumerable<Position> Positions { get; set; }

        public IEnumerable<SocialMedia> SocialMedias { get; set; }

        public IEnumerable<UserPosition> UsersPositions { get; set; }
    }
}
