namespace PhotoShare.Client.Core.Commands
{
    using System;


    using Contracts;
    using PhotoShare.Client.Core.Dtos;
    using PhotoShare.Services;
    using PhotoShare.Services.Contracts;

    public class RegisterUserCommand : ICommand
    {
        private readonly IUserService userService;
        private readonly IUserSessionService userSessionService;
        public RegisterUserCommand(IUserService userService, IUserSessionService userSessionService)
        {
            this.userSessionService = userSessionService;
            this.userService = userService;
        }

        // RegisterUser <username> <password> <repeat-password> <email>
        public string Execute(string[] data)
        {
            string username = data[0];
            string password = data[1];
            string email = data[3];
            if (userSessionService.User!=null)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (password != data[2])
            {
                return "Passwords do not match!";
            }
            if (this.userService.Exists(data[0]))
            {
                throw new InvalidOperationException($"Username {data[0]} is already taken!");
            }

            var result = userService.Register(username, password, email);

            return result;
        }

        //private bool IsValid(object obj)
        //{
        //    var validationContext = new ValidationContext(obj);
        //    var validationResults = new List<ValidationResult>();

        //    return Validator.TryValidateObject(obj, validationContext, validationResults, true);
        //}
    }
}
