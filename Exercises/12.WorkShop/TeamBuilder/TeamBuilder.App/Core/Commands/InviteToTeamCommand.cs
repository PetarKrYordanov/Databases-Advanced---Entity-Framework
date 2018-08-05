namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;
    public class InviteToTeamCommand
    {
        //•	InviteToTeam <teamName> <username>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(2, inputArgs);

            var currentUser = AuthenticationManager.GetCurrentUser();

            var teamName = inputArgs[0];
            var username = inputArgs[1];

            if (CommandHelper.IsUserExisting(username) == false || CommandHelper.IsTeamExisting(teamName) == false)
            {
                throw new ArgumentException(Constants.ErrorMessages.TeamOrUserNotExist);
            }

            var user = CommandHelper.GetUserByUsername(username);


            if (CommandHelper.IsInviteExisting(teamName, user))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.InviteIsAlreadySent);
            }

            if (CommandHelper.IsUserCreatorOfTeam(teamName, currentUser))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            if (CommandHelper.IsMemberOfTeam(teamName, username))
            {
                throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
            }

            this.AddInvitation(teamName, user);
            return $"Team {teamName} invited {username}!";
        }

        private void AddInvitation(string teamName, User user)
        {
            using (var context = new TeamBuilderContext())
            {
                var team = context.Teams.FirstOrDefault(e => e.Name == teamName);

                var invitation = new Invitation()
                {
                    TeamId = team.Id,
                    InvitedUserId = user.Id
                };
                context.Invitations.Add(invitation);
                context.SaveChanges();
            }
        }
    }
}
