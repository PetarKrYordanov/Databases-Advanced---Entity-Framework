namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;

    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class AddTeamToCommand
    {
        //•	AddTeamTo <eventName> <teamName>
        public string Execute(string[] inputArgs)
        {

            Check.CheckLength(2, inputArgs);

            var eventName = inputArgs[0];
            var teamName = inputArgs[1];

            if (!CommandHelper.IsTeamExisting(teamName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.TeamNotFound, teamName));
            }

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            var user = AuthenticationManager.GetCurrentUser();

            using (var context = new TeamBuilderContext())
            {
                var team = context.Teams.FirstOrDefault(e => e.Name == teamName);
                var eventObj = context.Events.FirstOrDefault(e => e.Name == eventName);

                if (user.Id != eventObj.CreatorId)
                {
                    throw new InvalidOperationException(Constants.ErrorMessages.NotAllowed);
                }

                if (context.EventTeams.Any(x => x.EventId == eventObj.Id && x.TeamId == team.Id))
                {
                    throw new InvalidOperationException(Constants.ErrorMessages.CannotAddSameTeamTwice);
                }

                var teamEvent = new EventTeam()
                {
                    TeamId = team.Id,
                    EventId = eventObj.Id
                };

                context.EventTeams.Add(teamEvent);
                context.SaveChanges();
            }
            return $"Team {teamName} added for {eventName}!";
        }
    }
}
