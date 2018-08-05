namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;

    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;
    public class DeclineInviteCommand
    {
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
                throw new ArgumentException(string.Format(Constants.ErrorMessages.InviteNotFound, teamName));
            }

            this.DeclineInvite(teamName, currentUser);


            return $"Invite from {teamName} declined.";
        }

        private void DeclineInvite(string teamName, User currentUser)
        {
            using (var context = new TeamBuilderContext())
            {
                var team = context.Teams.FirstOrDefault(e => e.Name == teamName);

                var invitation = context.Invitations.FirstOrDefault(e => e.InvitedUserId == currentUser.Id && e.TeamId == team.Id);
                invitation.IsActive = false;
                context.SaveChanges();
            }
        }
    }
}
