namespace TeamBuilder.App.Utilities
{
    using System.Linq;

    using TeamBuilder.Data;
    using TeamBuilder.Models;
    public static class CommandHelper
    {
        public static bool IsTeamExisting(string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.Name == teamName);
            }
        }
        public static bool IsUserExisting(string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Users.Any(t => t.Username == username);
            }
        }
        public static bool IsInviteExisting(string teamName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Invitations
                    .Any(i => i.Team.Name == teamName && i.InvitedUserId == user.Id && i.IsActive);
            }
        }
        public static bool IsUserCreatorOfTeam(string teamName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams.Any(t => t.CreatorId == user.Id && t.Name == teamName);
            }
        }

        internal static bool IsAlreadyMemberOfTeam(string username, string teamName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Invitations.Any(i=>i.Team.Name == teamName && i.InvitedUser.Username == username && i.IsActive==false);
            }
        }

        public static bool IsUserCreatorOfEvent(string eventName, User user)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Events.Any(e => e.CreatorId == user.Id && e.Name == eventName);
            }
        }

        public static bool IsMemberOfTeam(string teamName, string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Teams
                    .Single(t => t.Name == teamName)
                    .UserTeams.Any(ut => ut.User.Username == username);
            }
        }

        public static bool IsEventExisting(string eventName)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Events.Any(e => e.Name == eventName);
            }
        }
        public static User GetUserByUsername(string username)
        {
            using (TeamBuilderContext context = new TeamBuilderContext())
            {
                return context.Users.FirstOrDefault(e => e.Username == username);
            }
        }
    }
}
