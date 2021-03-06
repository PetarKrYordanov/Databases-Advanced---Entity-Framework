﻿namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Dtos;
    using Services.Contracts;
    using Contracts;
    using System.Text;

    public class ListFriendsCommand : ICommand
    {
        private readonly IUserService userService;
        public ListFriendsCommand(IUserService userService)
        {
            this.userService = userService;
        }
        public string Execute(string[] args)
        {
            var username = args[0];
            var result = new StringBuilder();

            if (!userService.Exists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var user = userService.ByUsername<UserFriendsDto>(username);
            if (user.Friends.Count==0)
            {
                result.Append ("No friends for this user. :(");
            }
            result.AppendLine("Friends:");
            foreach (var item in user.Friends)
            {
                result.AppendLine(item.Username);
            }

            return result.ToString().Trim();
        }
    }
}
