namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class AcceptInviteCommand
    {
        //•	AcceptInvite <teamName>
        public string Execute(string[] commandArgs)
        {
            Check.CheckLength(1, commandArgs);

            var currentUser = AuthenticationManager.GetCurrentUser();

            var teamName = commandArgs[0];

            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(Constants.ErrorMessages.TeamNotFound, teamName);
            }

            if (!CommandHelper.IsInviteExisting(teamName, currentUser))
            {
                throw new ArgumentException(string.Format(  Constants.ErrorMessages.InviteNotFound, teamName));
            }

            this.AcceptInvite(currentUser, teamName);

            return $"User {currentUser.Username} joined team {teamName}!";
        }

        private void AcceptInvite(User currentUser, string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                var teamId = context.Teams.FirstOrDefault(e => e.Name == teamName).Id;

                var userTeam = new UserTeam()
                {
                    UserId = currentUser.Id,
                    TeamId = teamId
                };

                var invite = context.Invitations.FirstOrDefault(e => e.InvitedUserId == currentUser.Id && e.TeamId == teamId);
                invite.IsActive = false;

                context.UserTeams.Add(userTeam);
                context.SaveChanges();
            }
        }
    }
}
