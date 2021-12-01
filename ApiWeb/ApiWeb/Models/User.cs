using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ApiWeb.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Position { get; set; }

        public DateTime Birthday { get; set; }

        public string UserIcon { get; set; }
    }
}
