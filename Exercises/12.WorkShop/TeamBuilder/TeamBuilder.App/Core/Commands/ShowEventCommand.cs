namespace TeamBuilder.App.Core.Commands
{
    using System;
    using System.Linq;
    using System.Text;
    using TeamBuilder.App.Utilities;
    using TeamBuilder.Data;
    public  class ShowEventCommand
    {
        //•	ShowEvent <eventName>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(1, inputArgs);

            var eventName = inputArgs[0];

            if (!CommandHelper.IsEventExisting(eventName))
            {
                throw new ArgumentException(string.Format(Constants.ErrorMessages.EventNotFound, eventName));
            }

            var sb = new StringBuilder();
            using (var context =new TeamBuilderContext())
            {
                var thisEvent = context.Events.FirstOrDefault(e => e.Name == eventName);

                sb.AppendLine($"{thisEvent.Name} {thisEvent.StartDate} {thisEvent.EndDate}");
                sb.AppendLine($"{thisEvent.Description}");

                sb.AppendLine("Teams:");
                foreach (var team in thisEvent.ParticipatingEventTeams)
                {
                    sb.AppendLine($"-{team.Team.Name}");
                }


            }
            return sb.ToString().TrimEnd();
        }

        
    }
}
