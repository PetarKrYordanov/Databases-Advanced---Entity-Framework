namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using PhotoShare.Services.Contracts;
    using Dtos;
    using System.Linq;

    public class AddFriendCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IUserSessionService userSessionService;
        public AddFriendCommand(IUserService userService,IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.userSessionService = userSessionService;
        }

        // AddFriend <username1> <username2>
        public string Execute(string[] data)
        {
            var requestSender = data[0];
            var requestReciever = data[1];

            if (userSessionService.User.Username !=requestSender)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            if (!userService.Exists(requestSender))
            {
                throw new ArgumentException($"{requestSender} not found!");
            }
            if (!userService.Exists(requestReciever))
            {
                throw new ArgumentException($"{requestReciever} not found!");
            }

            UserFriendsDto userFriendsDto = userService.ByUsername<UserFriendsDto>(requestSender);
            UserFriendsDto addFriendsDto = userService.ByUsername<UserFriendsDto>(requestReciever);
            bool areFriends = userFriendsDto.Friends.Any(x => x.Username == addFriendsDto.Username)
                            && addFriendsDto.Friends.Any(x => x.Username == userFriendsDto.Username);
            if (areFriends)
            {
                throw new InvalidOperationException($"{requestReciever} is already a friend to {requestSender}");
            }
            if (userFriendsDto.Friends.Any(x=>x.Username==requestSender))
            {
                throw new InvalidOperationException($"{requestSender} already has invitation from {requestSender}");
            }
            var senderId = userService.ByUsername<UserDto>(requestSender).Id;
            var recieverId= userService.ByUsername<UserDto>(requestReciever).Id;


            var friendShip = userService.AddFriend(senderId, recieverId);


            return $"Friend {requestReciever} added to {requestSender}";
        }

    }
}
