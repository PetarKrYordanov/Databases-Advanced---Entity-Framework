using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Stations.Data;
using Stations.DataProcessor.Dto.Import;
using Stations.Models;
using Stations.Models.Enums;

namespace Stations.DataProcessor
{
    public static class Deserializer
    {
        private const string FailureMessage = "Invalid data format.";
        private const string SuccessMessage = "Record {0} successfully imported.";

        public static string ImportStations(StationsDbContext context, string jsonString)
        {

            var sb = new StringBuilder();
            var validStations = new List<Station>();

            var deserializedItems = JsonConvert.DeserializeObject<Station[]>(jsonString, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Include
            });

            foreach (var item in deserializedItems)
            {
                if (item.Town == null)
                {
                    item.Town = item.Name;
                }
                if (validStations.Any(e => e.Name == item.Name))
                {
                    sb.AppendLine("Invalid data format.");
                    continue;
                }
                if (!IsValid(item))
                {
                    sb.AppendLine("Invalid data format.");
                    continue;
                }
                validStations.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }
            context.Stations.AddRange(validStations);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportClasses(StationsDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var validSeatingClasses = new List<SeatingClass>();

            var deserializedItems = JsonConvert.DeserializeObject<SeatingClass[]>(jsonString, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Include
            });

            foreach (var item in deserializedItems)
            {
                if (!IsValid(item))
                {
                    sb.AppendLine("Invalid data format.");
                    continue;
                }
                if (validSeatingClasses.Any(e => e.Name == item.Name))
                {
                    sb.AppendLine("Invalid data format.");
                    continue;
                }
                if (validSeatingClasses.Any(e => e.Abbreviation == item.Abbreviation))
                {
                    sb.AppendLine("Invalid data format.");
                    continue;
                }
                validSeatingClasses.Add(item);
                sb.AppendLine(string.Format(SuccessMessage, item.Name));
            }
            context.SeatingClasses.AddRange(validSeatingClasses);
            context.SaveChanges();

            return sb.ToString().TrimEnd();

        }

        public static string ImportTrains(StationsDbContext context, string jsonString)
        {
            var deserializedTrains = JsonConvert.DeserializeObject<TrainDto[]>(jsonString, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var sb = new StringBuilder();

            var validTrains = new List<Train>();
            foreach (var trainDto in deserializedTrains)
            {
                if (!IsValid(trainDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var trainAlreadyExists = validTrains.Any(t => t.TrainNumber == trainDto.TrainNumber);
                if (trainAlreadyExists)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatsAreValid = trainDto.Seats.All(IsValid);
                if (!seatsAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var seatingClassesAreValid = trainDto.Seats
                    .All(s => context.SeatingClasses.Any(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation));
                if (!seatingClassesAreValid)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var type = Enum.Parse<TrainType>(trainDto.Type);

                var trainSeats = trainDto.Seats.Select(s => new TrainSeat
                {
                    SeatingClass =
                            context.SeatingClasses.SingleOrDefault(sc => sc.Name == s.Name && sc.Abbreviation == s.Abbreviation),
                    Quantity = s.Quantity.Value
                })
                    .ToArray();

                var train = new Train
                {
                    TrainNumber = trainDto.TrainNumber,
                    Type = type,
                    TrainSeats = trainSeats
                };

                validTrains.Add(train);

                sb.AppendLine(string.Format(SuccessMessage, trainDto.TrainNumber));
            }

            context.Trains.AddRange(validTrains);
            context.SaveChanges();

            var result = sb.ToString();
            return result;
        }

        public static string ImportTrips(StationsDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var validTrips = new List<Trip>();

            var deserializedItems = JsonConvert.DeserializeObject<TripDto[]>(jsonString, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Include
            });

            foreach (var tripDto in deserializedItems)
            {
                var train = context.Trains.FirstOrDefault(e => e.TrainNumber == tripDto.Train);
                if (train == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                if (!IsValid(tripDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var originStation = context.Stations.FirstOrDefault(e => e.Name == tripDto.OriginStation);
                if (originStation == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var destionationStation = context.Stations.FirstOrDefault(e => e.Name == tripDto.DestinationStation);
                if (destionationStation == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                DateTime departureTime;
                if (!DateTime.TryParseExact(tripDto.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out departureTime))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                DateTime arrivalTime;
                if (!DateTime.TryParseExact(tripDto.ArrivalTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out arrivalTime))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                if (arrivalTime < departureTime)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var statusAsEnum = Enum.Parse<TripSatus>(tripDto.Status);
                TimeSpan timeSpan;
                TimeSpan.TryParseExact(tripDto.TimeDifference, @"hh:mm", CultureInfo.InvariantCulture, out timeSpan);

                var trip = new Trip()
                {
                    ArrivalTime = arrivalTime,
                    DepartureTime = departureTime,
                    DestinationStationId = destionationStation.Id,
                    OriginStationId = originStation.Id,
                    TimeDifference = timeSpan,
                    TrainId = train.Id,
                    Status = Enum.Parse<TripSatus>(tripDto.Status)
                };
                sb.AppendLine($"Trip from {originStation.Name} to {tripDto.DestinationStation} imported.");
                validTrips.Add(trip);
            }

            context.Trips.AddRange(validTrips);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportCards(StationsDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(CardDto[]), new XmlRootAttribute("Cards"));
            var deserializedCards = (CardDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var validCards = new List<CustomerCard>();

            foreach (var cardDto in deserializedCards)
            {
                if (!IsValid(cardDto))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                if (cardDto.CardType == null)
                {
                    cardDto.CardType = "Normal";
                }

                CardType cardType = Enum.Parse<CardType>(cardDto.CardType);

                var validCard = new CustomerCard()
                {
                    Name = cardDto.Name,
                    Age = cardDto.Age,
                    Type = cardType
                };
                validCards.Add(validCard);
                sb.AppendLine(string.Format(SuccessMessage, validCard.Name));
            }
            context.AddRange(validCards);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportTickets(StationsDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(TicketDto[]), new XmlRootAttribute("Tickets"));
            var deserializedTickets = (TicketDto[])serializer.Deserialize(new MemoryStream(Encoding.UTF8.GetBytes(xmlString)));

            var validTickets = new List<Ticket>();

            foreach (var item in deserializedTickets)
            {
                var departureTime = DateTime.ParseExact(item.Trip.DepartureTime, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None);
                var trip = context.Trips
                    .Include(e => e.OriginStation)
                    .Include(e => e.DestinationStation)
                    .Include(e => e.Train)
                    .ThenInclude(e => e.TrainSeats)
                    .SingleOrDefault(e => e.DepartureTime == departureTime && e.DestinationStation.Name == item.Trip.DestinationStation && e.OriginStation.Name == item.Trip.OriginStation);

                if (trip == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                if (!IsValid(item))
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }

                var searchedAbbreviationArr = item.Seat.Take(2).ToArray();
                var searchedAbbreviation = string.Join("", searchedAbbreviationArr);

                var placeNumber = int.Parse(string.Join("", item.Seat.Skip(2).ToArray()));

                var seatExists = trip.Train.TrainSeats
                    .SingleOrDefault(s => s.SeatingClass.Abbreviation == searchedAbbreviation && placeNumber <= s.Quantity);

                if (seatExists == null)
                {
                    sb.AppendLine(FailureMessage);
                    continue;
                }
                CustomerCard card = null;
                if (item.Card != null)
                {
                    card = context.Cards.SingleOrDefault(c => c.Name == item.Card.Name);

                    if (card == null)
                    {
                        sb.AppendLine(FailureMessage);
                        continue;
                    }
                }
                var ticket = new Ticket()
                {
                    CustomerCard = card,
                    Price = item.Price,
                    Trip = trip,
                    SeatingPlace = item.Seat
                };



                validTickets.Add(ticket);
                sb.AppendLine($"Ticket from {item.Trip.OriginStation} to {item.Trip.DestinationStation}" +
                    $" departing at {departureTime} imported.");
            }
            context.AddRange(validTickets);
            context.SaveChanges();

        

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object obj)
        {
            var context = new System.ComponentModel.DataAnnotations.ValidationContext(obj, serviceProvider: null, items: null);

            var resilts = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(obj, context, resilts, true);
            return isValid;
        }
    }
}