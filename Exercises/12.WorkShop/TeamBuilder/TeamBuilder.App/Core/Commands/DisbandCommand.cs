namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class DisbandCommand
    {
        //        •	Disband<teamName>
        //Deletes given team.Allowed for the team’s creator only.

        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            User user = AuthenticationManager.GetCurrentUser();

            var teamName = inputArgs[0];
            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            using (var context = new TeamBuilderContext())
            {
                var team = context.Teams.FirstOrDefault(e => e.Name == teamName);

                if (user.Id != team.CreatorId)
                {
                    throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
                }

                context.Teams.Remove(team);
                context.SaveChanges();
            }
            return $"{teamName} was disbanded!";
        }

    }
}
