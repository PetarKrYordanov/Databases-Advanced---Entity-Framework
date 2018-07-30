namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using PhotoShare.Services.Contracts;
    public class AddTagCommand : ICommand
    {
        private readonly ITagService tagService;
        private readonly IUserSessionService userSessionService;
        public AddTagCommand(ITagService tagService, IUserSessionService userSessionService)
        {
            this.tagService = tagService;
            this.userSessionService = userSessionService;
        }
        //AddTag <tag>
        public string Execute(string[] args)
        {
            var tag = args[0];

            if (userSessionService.User !=null)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            var tagExists = tagService.Exists(tag);
            if (tagExists)
            {
                throw new ArgumentException($"Tag {tag} exists");
            }

           var tagClass = tagService.AddTag(tag);
            return $"Tag {tag} was added successfully!";
        }
    }
}
