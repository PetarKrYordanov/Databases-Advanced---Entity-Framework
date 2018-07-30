namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Dtos;
    using Contracts;
    using Services.Contracts;
    using PhotoShare.Services;

    public class AddTownCommand : ICommand
    {
        private readonly ITownService townService;
        private readonly IUserSessionService userSessionService;
        public AddTownCommand(ITownService townService, IUserSessionService userSessionService)
        {
            this.townService = townService;
            this.userSessionService = userSessionService;
        }

        // AddTown <townName> <countryName>
        public string Execute(string[] data)
        {
            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            string townName = data[0];
            string country = data[1];

            var townExists = townService.Exists(townName);

            if (townExists)
            {
                throw new ArgumentException($"Town {townName} was already added!");
            }
            var townDto = new TownDto() { TownName = townName, CountryName = country };
            var town = townService.Add(townName, country);

            return $"Town {townName} was added successfully!";
        }
    }
}
