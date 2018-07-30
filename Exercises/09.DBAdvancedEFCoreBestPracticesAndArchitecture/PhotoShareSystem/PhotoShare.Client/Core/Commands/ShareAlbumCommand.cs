namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using PhotoShare.Services.Contracts;
    using PhotoShare.Models.Enums;
    using Dtos;

    public class ShareAlbumCommand : ICommand
    {
        private readonly IAlbumRoleService albumRoleService;
        private readonly IUserService userService;
        private readonly IAlbumService albumService;
        private readonly IUserSessionService userSessionService;
        public ShareAlbumCommand(IAlbumRoleService roleService, IUserService userService, IAlbumService albumService, IUserSessionService userSessionService)
        {
            this.albumRoleService = roleService;
            this.userService = userService;
            this.albumService = albumService;
            this.userSessionService = userSessionService; 
        }
        // ShareAlbum <albumId> <username> <permission>
        // For example:
        // ShareAlbum 4 dragon321 Owner
        // ShareAlbum 4 dragon11 Viewer
        public string Execute(string[] data)
        {
            var albumId = int.Parse(data[0]);
            var username = data[1];
            var isValidPermision = Enum.TryParse( data[2], out Role permision);
            if (username != this.userSessionService.User.Username&& permision==Role.Owner)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            if (!albumService.Exists(albumId))
            {
                throw new ArgumentException($"Album {albumId} not found!");
            }

            if (!isValidPermision)
            {
                throw new ArgumentException("Permission must be either “Owner” or “Viewer!");
            }

            if (!userService.Exists(username))
            {
                throw new ArgumentException($"User {username} not found!");
            }
            var userDto = userService.ByUsername<UserDto>(username);

         var albumrole =   albumRoleService.PublishAlbumRole(albumId, userDto.Id, data[2]);

            return $"Username {username} added to album {albumrole.Album.Name} ({data[2]})";
        }
    }
}
