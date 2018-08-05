using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TeamBuilder.Models
{
    public class Team
    {
        public Team()
        {
            this.Invitations = new List<Invitation>();
            this.UserTeams = new List<UserTeam>();
            this.EventTeams = new List<EventTeam>();
        }
        public int Id { get; set; }

        [MaxLength(25)]
        [Required]
        public string Name { get; set; }

        [MaxLength(32)]
        public string Description{ get; set; }
        [StringLength(3,MinimumLength =3)]
        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public virtual User Creator { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }

        public virtual ICollection<UserTeam> UserTeams { get; set; }

        public virtual ICollection<EventTeam> EventTeams { get; set; }

    }
}
