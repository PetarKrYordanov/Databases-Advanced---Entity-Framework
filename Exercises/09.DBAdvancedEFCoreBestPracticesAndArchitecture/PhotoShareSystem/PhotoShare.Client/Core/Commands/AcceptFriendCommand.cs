namespace PhotoShare.Client.Core.Commands
{
    using System;
    using Contracts;
    using Services.Contracts;
    using Dtos;
    public class AcceptFriendCommand : ICommand
    {
        private readonly IUserService userService;
        public AcceptFriendCommand(IUserService userService)
        {
            this.userService = userService;
        }

        // AcceptFriend <username1> <username2>
        public string Execute(string[] data)
        {
            var requestSender = data[0];
            var requestReciever = data[1];

            if (!userService.Exists(requestSender))
            {
                throw new ArgumentException($"{requestSender} not found!");
            }
            if (!userService.Exists(requestReciever))
            {
                throw new ArgumentException($"{requestReciever} not found!");
            }
            var recieverId = this.userService.ByUsername<UserDto>(requestSender).Id;
            var senderId = this.userService.ByUsername<UserDto>(requestReciever).Id;

            var friendship = this.userService.AcceptFriend(recieverId, senderId);
            return $"{requestSender} accepted {requestReciever} as a friend";
        }
    }
}
