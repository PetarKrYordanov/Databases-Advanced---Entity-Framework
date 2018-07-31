namespace ProductShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {

        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        [MinLength(3)]
        public string LastName { get; set; }
        public int? Age { get; set; }
        public ICollection<UserFriend> FriendsUsers { get; set; } = new HashSet<UserFriend>();
        public ICollection<UserFriend> UsersFriends { get; set; } = new HashSet<UserFriend>();
        public ICollection<Product> SoldProducts{ get; set; } = new HashSet<Product>();
        public ICollection<Product> BoughtProduct { get; set; } = new HashSet<Product>();
    }
}
