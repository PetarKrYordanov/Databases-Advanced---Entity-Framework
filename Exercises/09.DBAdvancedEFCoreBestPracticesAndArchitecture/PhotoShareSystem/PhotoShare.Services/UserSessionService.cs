namespace PhotoShare.Services
{
    using Contracts;
    using Models;
    public class UserSessionService : IUserSessionService
    {
        private readonly IUserService userService;
        public UserSessionService(IUserService userService)
        {
            this.userService = userService;
        }
        public User User { get; private set; }

        public bool IsLoggedIn()
        {
            return this.User != null;
        }

        public User Login(string name, string password)
        {
            this.User = userService.ByUsernameAndPassword<User>(name, password);
            return this.User;
        }

        public void LogOut()
        {
            this.User = null;
        }
    }
}
