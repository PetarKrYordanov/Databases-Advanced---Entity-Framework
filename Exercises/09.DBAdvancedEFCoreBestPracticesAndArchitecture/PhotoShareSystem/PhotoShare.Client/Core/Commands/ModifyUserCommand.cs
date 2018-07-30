namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using Services.Contracts;
    using Dtos;
    using System.Linq;

    public class ModifyUserCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly ITownService townService;
        private readonly IUserSessionService userSessionService;
        public ModifyUserCommand(IUserService userService, ITownService townService,IUserSessionService userSessionService)
        {
            this.userService = userService;
            this.townService = townService;
            this.userSessionService = userSessionService;
        }

        // ModifyUser <username> <property> <new value>
        // For example:
        // ModifyUser <username> Password <NewPassword>
        // ModifyUser <username> BornTown <newBornTownName>
        // ModifyUser <username> CurrentTown <newCurrentTownName>
        // !!! Cannot change username
        public string Execute(string[] data)
        {
            var username = data[0];
            var property = data[1];
            var newValue = data[2];

            if (username != this.userSessionService.User.Username)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (!userService.Exists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }
            var result = string.Empty;

            var userDto = userService.ByUsername<UserDto>(username);

            switch (property.ToLower())
            {
                case "currenttown":
                    if (!townService.Exists(newValue))
                    {
                        throw new ArgumentException($"Value {newValue} not valid." +
                            $"{Environment.NewLine}Town {newValue} not found!");
                    }
                    else
                    {
                        var townDto = townService.ByName<TownDto>(newValue);
                        userService.SetCurrentTown(userDto.Id, townDto.Id);
                        result = $"User {username} {property} is {newValue}.";
                    }
                    break;
                case "borntown":
                    if (!townService.Exists(newValue))
                    {
                        throw new ArgumentException($"Value {newValue} not valid." +
                            $"{Environment.NewLine}Town {newValue} not found!");
                    }
                    else
                    {
                        var townDto = townService.ByName<TownDto>(newValue);
                        userService.SetBornTown(userDto.Id, townDto.Id);
                        result = $"User {username} {property} is {newValue}.";
                    }
                    break;
                case "password":
                    if (newValue.Any(x=>Char.IsDigit(x)) && newValue.Any(x=>Char.IsLower(x)) )
                    {
                        userService.ChangePassword(userDto.Id, newValue);
                        result = $"User {username} {property} is {newValue}.";
                    }
                    else
                    {
                        throw new ArgumentException($"Value {newValue} not valid." +
                              $"{Environment.NewLine}Invalid Password");
                    }
                    break;
                default:
                    throw new ArgumentException($"Property {property} not supported!");
            }

            return result;
        }
    }
}
