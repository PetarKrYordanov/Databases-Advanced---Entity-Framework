namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;

    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;
    class RegisterUserCommand
    {
        //•	RegisterUser <username> <password> <repeat-password> <firstName> <lastName> <age> <gender>
        public string Execute(string[] args)
        {
            var result = string.Empty;
            Check.CheckLength(7, args);
            string username = args[0];

            //validate given username
            if (username.Length < Constants.MinUsernameLength || username.Length > Constants.MaxUsernameLength)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid, username));
            }

            string password = args[1];

            //Validate Password 
            if (!password.Any(char.IsDigit) || !password.Any(char.IsUpper))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, password));
            }

            string repeatedPassword = args[2];
            // validate passwods 
            if (password != repeatedPassword)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordDoesNotMatch));
            }

            string firstName = args[3];
            string lastName = args[4];

            int age;
            bool isNumer = int.TryParse(args[5], out age);

            if (!isNumer || age<=0)
            {
                throw new ArgumentException(Constants.ErrorMessages.AgeNotValid);
            }

            Gender gender;
            bool isGenderValid = Enum.TryParse(args[6], out gender);
            if (!isGenderValid)
            {
                throw new ArgumentException(Constants.ErrorMessages.GenderNotValid);
            }

            if (CommandHelper.IsUserExisting(username))
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.UsernameIsTaken,username));
            }
            this.RegisterUser(username, password, firstName, lastName, age, gender);

            return $"User {username} was registered successfully!";
        }

       private void RegisterUser(string username, string password, string firstName, string lastName, int age, Gender gender)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                User user = new User()
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Gender = gender,
                    Age = age
                };

                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
