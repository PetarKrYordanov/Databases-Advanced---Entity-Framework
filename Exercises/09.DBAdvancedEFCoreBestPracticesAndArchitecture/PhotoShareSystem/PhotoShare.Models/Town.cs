namespace PhotoShare.Models
{
    using System.Collections.Generic;

    public class Town
    {
        public Town()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public ICollection<User> UsersBornInTown { get; set; } = new HashSet<User>();

        public ICollection<User> UsersCurrentlyLivingInTown { get; set; } = new HashSet<User>();
    }
}
