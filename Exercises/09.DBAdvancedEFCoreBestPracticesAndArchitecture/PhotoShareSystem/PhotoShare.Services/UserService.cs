namespace PhotoShare.Services
{
    using System;
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using Contracts;
    using PhotoShare.Models;
    using PhotoShare.Data;

    public class UserService : IUserService
    {
        private PhotoShareContext context;
        public UserService(PhotoShareContext photoShareContext)
        {
            this.context = photoShareContext;
        }
        public Friendship AcceptFriend(int userId, int friendId)
        {
            bool areAlreadyFriends = this.context.Friendships.Any(x => x.FriendId == userId &&x.UserId ==friendId) && this.context.Friendships.Any(x => x.UserId == userId && x.FriendId ==friendId) == true;
            var usernameReciever = ById<User>(userId).Username;
            var usernameSender = ById<User>(friendId).Username;
            if (areAlreadyFriends)
            {
                throw new InvalidOperationException($"{usernameReciever} is already a friend to {usernameSender}");
            }
            if (!this.context.Friendships.Any(x=>x.UserId == friendId && x.FriendId==userId))
            {
                throw new InvalidOperationException($"{usernameSender} has not added {usernameReciever} as a friend");
            }

            var friendship = new Friendship() { UserId = userId, FriendId = friendId };
            this.context.Friendships.Add(friendship);
            this.context.SaveChanges();
            return friendship;
        }

        public Friendship AddFriend(int userId, int friendId)
        {
            Friendship friendship = new Friendship() { UserId = userId, FriendId = friendId };

            this.context.Friendships.Add(friendship);
            this.context.SaveChanges();
            return friendship;
        }
        public TModel ByUsernameAndPassword<TModel>(string username, string password)
        {
            TModel model = this.context.Users
                .Where(x => x.Username == username && x.Password == password)
                .ProjectTo<TModel>()
                .FirstOrDefault();
            return model;
        }
        public TModel ById<TModel>(int id)
        {
            TModel model = this.context.Users
                .Where(t => t.Id == id)
                .ProjectTo<TModel>().First();
            return model;
        }

        public TModel ByUsername<TModel>(string username)
        {
            TModel userDto = this.context.Users
                .Where(e => e.Username == username)
                .ProjectTo<TModel>()
                .SingleOrDefault();

            return userDto;
        }

        public void ChangePassword(int userId, string password)
        {
            var user = this.context.Users.Find(userId);
            user.Password = password;
            this.context.Users.Update(user);
            this.context.SaveChanges();
        }

        public void Delete(string username)
        {
            var user = this.context.Users
                .Where(e => e.Username == username)
                .FirstOrDefault();
            user.IsDeleted = true;

            this.context.Users.Update(user);
            this.context.SaveChanges();
        }

        public bool Exists(int id)
        {
            var user = context.Users.Any(e => e.Id == id);
            if (user)
            {
                return true;
            }
            return false;
        }

        public bool Exists(string name)
        {
            var user = context.Users.Any(e => e.Username == name);
            if (user)
            {
                return true;
            }
            return false;
        }

        public string Register(string username, string password, string email)
        {
            var user = new User()
            {
                Username = username,
                Password = password,
                Email = email
            };
            context.Users.Add(user);
            this.context.SaveChanges();
            return $"User {username} was registered successfully";
        }

        public void SetBornTown(int userId, int townId)
        {
            var user = this.context.Users.Find(userId);
            user.BornTownId = townId;
            this.context.Users.Update(user);
            this.context.SaveChanges();
        }

        public void SetCurrentTown(int userId, int townId)
        {
            var user = this.context.Users.Find(userId);
            user.CurrentTownId = townId;
            this.context.Users.Update(user);
            this.context.SaveChanges();
        }

    }
}