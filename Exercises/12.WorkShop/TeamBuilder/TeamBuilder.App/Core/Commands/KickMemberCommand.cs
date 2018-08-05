namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;

    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    public class KickMemberCommand
    {
        //•	KickMember <teamName> <username>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            var teamName = inputArgs[0];
            if (CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            var username = inputArgs[1];
            if (CommandHelper.IsUserExisting(username))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UserNotFound, username));
            }

            var currentUser = AuthenticationManager.GetCurrentUser();

            if (!CommandHelper.IsMemberOfTeam(teamName, username))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.NotPartOfTeam, username, teamName));
            }

            if (!CommandHelper.IsUserCreatorOfTeam(teamName, currentUser))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            if (username == currentUser.Username)
            {
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.CommandNotAllowed, "DisbandTeam"));
            }

            this.KickMember(teamName, username);
            return $"User {username} was kicked from {teamName}!";
        }

        private void KickMember(string teamName, string username)
        {
            using (var context = new TeamBuilderContext())
            {
                var team = context.Teams.FirstOrDefault(e => e.Name == teamName);
                var user = context.Users.FirstOrDefault(e => e.Username == username);

                var userTeeam = context.UserTeams.FirstOrDefault(e => e.TeamId == team.Id && e.UserId == user.Id);

                context.UserTeams.Remove(userTeeam);
                context.SaveChanges();
            }
        }
    }
}
