using System;
using ApiWeb.Domain;

namespace ApiWeb.Domain
{
	public class SocialMedia 
	{
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }
    }
}