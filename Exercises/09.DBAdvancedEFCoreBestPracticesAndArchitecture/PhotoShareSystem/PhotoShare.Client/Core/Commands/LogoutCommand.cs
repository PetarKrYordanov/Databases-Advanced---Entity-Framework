namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using Services.Contracts;
    class LogoutCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IUserSessionService userSessionService;
        public LogoutCommand(IUserService userService,IUserSessionService userSessionService)
        {
            this.userSessionService = userSessionService;
            this.userService = userService;
        }
        public string Execute(string[] args)
        {
            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("You should log in first in order to logout.");
            }

            var user = userSessionService.User;
            userSessionService.LogOut();

            return $"User {user.Username} successfully logged out!";
        }
    }
}
