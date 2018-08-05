namespace TeamBuilder.App.Core.Commands
{
    using System;

    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;
    public class CreateTeamCommand
    {
        //•	CreateTeam <name> <acronym> <description>
        public string Execute(string[] args)
        {
            Check.CheckLength(3, args);
            AuthenticationManager.Authorize();

            var teamName = args[0];
            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamExists, teamName));
            }

            var acronym = args[1];
            if (acronym.Length != 3)
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InvalidAcronym, acronym));
            }

            var description = args[2];
            var creatorId = AuthenticationManager.GetCurrentUser().Id;

            this.CreateTeam(teamName, acronym, description, creatorId);
            return $"Team {teamName} successfully created!";
        }

        private void CreateTeam(string teamName, string acronym, string description, int creatorId)
        {
            using (var context = new TeamBuilderContext())
            {
                var team = new Team()
                {
                    Name = teamName,
                    Acronym = acronym,
                    Description = description,
                    CreatorId = creatorId
                };
                context.Teams.Add(team);
                context.SaveChanges();
            }
        }
    }
}
