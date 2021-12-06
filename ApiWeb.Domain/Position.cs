using System;
using System.Collections.Generic;

namespace ApiWeb.Domain 
{
	public class Position
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }
         
        public IEnumerable<UserPosition> UsersPositions  { get; set; }
    }
}