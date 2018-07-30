namespace PhotoShare.Services.Contracts
{
    using Models;
  public  interface IUserSessionService
    {
        User User { get; }
        User Login(string name, string password);
        void LogOut();
        bool IsLoggedIn();

    }
}
