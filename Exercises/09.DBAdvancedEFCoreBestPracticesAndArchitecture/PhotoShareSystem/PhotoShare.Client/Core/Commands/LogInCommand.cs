namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Models;
    using Contracts;
    using Services.Contracts;
    class LogInCommand : ICommand
    {
        private readonly IUserSessionService userSessionService;
        private readonly IUserService userService;
        public LogInCommand(IUserSessionService sessionService, IUserService userService)
        {
            this.userService = userService;
            this.userSessionService = sessionService;
        }

        // LogIn Username Password
        public string Execute(string[] args)
        {
            var username = args[0];
            var password = args[1];

            if (userSessionService.IsLoggedIn())
            {
                throw new ArgumentException("You should logout first!");
            }

            var userExists = userService.Exists(username);
            if (!userExists)
            {
                throw new ArgumentException("Invalid username or password");
            }

            User user = userService.ByUsername<User>(username);
            if (user.Password !=password)
            {
                throw new ArgumentException("Invalid username or password");
            }
            var logedUser = userSessionService.Login(username, password);

            return $"User {username} successfully logged in!";
        }
    }
}
