namespace PhotoShare.Client.Core.Commands
{
    using System;
    using System.Linq;

    using Contracts;
    using Models.Enums;
    using Services.Contracts;
    using Dtos;

    public class CreateAlbumCommand : ICommand
    {
        private readonly IAlbumService albumService;
        private readonly IUserService userService;
        private readonly ITagService tagService;
        private readonly IUserSessionService userSessionService;

        public CreateAlbumCommand(IAlbumService albumService, IUserService userService, ITagService tagService,IUserSessionService userSessionService)
        {
            this.albumService = albumService;
            this.userService = userService;
            this.tagService = tagService;
            this.userSessionService = userSessionService;
        }

        // CreateAlbum <username> <albumTitle> <BgColor> <tag1> <tag2>...<tagN>
        public string Execute(string[] data)
        {
            var username = data[0];
            var albumTitle = data[1];
            var backGroundColor = data[2];
            var tags = data.Skip(3).ToArray();

            if (username != this.userSessionService.User.Username)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }

            if (!userService.Exists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }

            if (albumService.Exists(username))
            {
                throw new ArgumentException($"Album {albumTitle} exists!");
            }

            var color = Enum.TryParse<Color>(backGroundColor, true, out Color parsedColor);

            if (!color)
            {
                throw new ArgumentException($"Color {backGroundColor} not found!");
            }

            if (!tags.All(x=>tagService.Exists(x)))
            {
                throw new ArgumentException("Invalid tags!");
            }

            var user = userService.ByUsername<UserDto>(username);
            var album = albumService.Create(user.Id, albumTitle, parsedColor, tags);

            return $"Album {albumTitle} successfully created!";
        }
    }
}
