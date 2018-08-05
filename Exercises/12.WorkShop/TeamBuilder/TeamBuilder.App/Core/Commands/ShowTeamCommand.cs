namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;

    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    public  class ShowTeamCommand
    {
        //•	ShowTeam<teamName>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            var teamName = inputArgs[0];
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            var sb = new StringBuilder();

            using (var context = new TeamBuilderContext())
            {
                var team = context.Teams.FirstOrDefault(e => e.Name == teamName);

                sb.AppendLine($"{team.Name} {team.Acronym}");

                sb.AppendLine($"Members:");
                foreach (var userTeam in team.UserTeams)
                {
                    sb.AppendLine($"--{userTeam.User.Username}");
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
