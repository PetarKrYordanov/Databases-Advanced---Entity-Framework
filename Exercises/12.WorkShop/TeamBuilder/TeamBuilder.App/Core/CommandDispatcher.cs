namespace TeamBuilder.App.Core
{
    using System;
    using System.Linq;

    using TeamBuilder.App.Core.Commands;
    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty;

            string[] inputArgs = input
                .Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            string commandName = inputArgs.Length > 0 ? inputArgs[0] : string.Empty;
            inputArgs = inputArgs.Skip(1).ToArray();

            switch (commandName.ToLower())
            {
                case "exit":
                    ExitCommand exit = new ExitCommand();
                    exit.Execute(inputArgs);
                    break;
                case "registeruser":
                    RegisterUserCommand registerUserCommand = new RegisterUserCommand();
                    result = registerUserCommand.Execute(inputArgs);
                    break;
                case "login":
                    LoginCommand login = new LoginCommand();
                    result = login.Execute(inputArgs);
                    break;
                case "logout":
                    LogoutCommand logoutCommand = new LogoutCommand();
                    result = logoutCommand.Execute(inputArgs);
                    break;
                case "deleteuser":
                    DeleteUserCommand deleteUserCommand = new DeleteUserCommand();
                    result = deleteUserCommand.Execute(inputArgs);
                    break;
                case "createevent":
                    CreateEventCommand createEvent = new CreateEventCommand();
                    result = createEvent.Execute(inputArgs);
                    break;
                case "createteam":
                    CreateTeamCommand createTeam = new CreateTeamCommand();
                    result = createTeam.Execute(inputArgs);
                    break;
                case "invitetoteam":
                    InviteToTeamCommand inviteToTeamCommand = new InviteToTeamCommand();
                    result = inviteToTeamCommand.Execute(inputArgs);
                    break;
                case "acceptinvite":
                    AcceptInviteCommand acceptInviteCommand = new AcceptInviteCommand();
                    result = acceptInviteCommand.Execute(inputArgs);
                    break;
                case "declineinvite":
                    DeclineInviteCommand declineInviteCommand = new DeclineInviteCommand();
                    result = declineInviteCommand.Execute(inputArgs);
                    break;
                case "kickmember":
                    KickMemberCommand kickMemberCommand = new KickMemberCommand();
                    result = kickMemberCommand.Execute(inputArgs);
                    break;
                case "disband":
                    DisbandCommand disbandCommand = new DisbandCommand();
                    result = disbandCommand.Execute(inputArgs);
                    break;
                case "addteamto":
                    AddTeamToCommand addTeamToCommand = new AddTeamToCommand();
                    result = addTeamToCommand.Execute(inputArgs);
                    break;
                case "showevent":
                    ShowEventCommand showEventCommand = new ShowEventCommand();
                    result = showEventCommand.Execute(inputArgs);
                    break;
                case "showteam":
                    ShowTeamCommand showTeamCommand = new ShowTeamCommand();
                    result = showTeamCommand.Execute(inputArgs);
                    break;
                default:
                    throw new NotSupportedException($"Command {commandName} not supported!");
            }

            return result;
        }
    }
}
