using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
namespace TeamBuilder.Models
{
    public class User
    {
        public User()
        {
            this.CreatedEvents  = new List<Event>();
            this.UserTeams = new List<UserTeam>();
            this.CreatedUserTeams = new List<Team>();
            this.RecievedInvitations = new List<Invitation>();
        }
        public int Id { get; set; }
              
        [Required]
        [MinLength(3),MaxLength(25)]
        public string Username { get; set; }
        [MaxLength(25)]
        public string FirstName { get; set; }
          [MaxLength(25)]
        public string LastName { get; set; }
        [MinLength(6),MaxLength(30)]
        public string Password { get; set; }

        public Gender Gender{ get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Event> CreatedEvents { get; set; } 

        public virtual ICollection<UserTeam> UserTeams { get; set; }

        public virtual ICollection<Team> CreatedUserTeams { get; set; }

        public virtual ICollection<Invitation> RecievedInvitations { get; set; } 
    }
}
