using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TeamBuilder.App.Utilities;
using TeamBuilder.Data;
using TeamBuilder.Models;

namespace TeamBuilder.App.Core.Commands
{
  public  class CreateEventCommand
    {
        //•	CreateEvent <name> <description> <startDate> <endDate>
        public string Execute(string[] inputArgs)
        {
            Check.CheckLength(6, inputArgs);
            AuthenticationManager.Authorize();
            var currentUser = AuthenticationManager.GetCurrentUser();
            var eventName = inputArgs[0];
            var description = inputArgs[1];

            DateTime startDate = ParseDate(inputArgs[2], inputArgs[3]);
            DateTime endDate = ParseDate(inputArgs[4], inputArgs[5]);

            if (startDate>endDate)
            {
                throw new ArgumentException("Start date should be before end date.");
            }

            var @event = new Event()
            {
                CreatorId = currentUser.Id,
                Name = eventName,
                Description = description,
                StartDate = startDate,
                EndDate = endDate
            };

            using (var context = new TeamBuilderContext())
            {
                context.Events.Add(@event);
                context.SaveChanges();
            }

            return $"Event {eventName} was created successfully!";
        }

        private DateTime ParseDate(string date, string hour)
        {
            var completeDateString = $"{date} {hour}";

            DateTime parsedDate;
            var isDateValid = DateTime.TryParseExact(completeDateString,
                Constants.DateTimeFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out parsedDate);

            if (!isDateValid)
            {
                throw new ArgumentException(Constants.ErrorMessages.InvalidDateFormat);
            }

            return parsedDate;
        }
    }
}
