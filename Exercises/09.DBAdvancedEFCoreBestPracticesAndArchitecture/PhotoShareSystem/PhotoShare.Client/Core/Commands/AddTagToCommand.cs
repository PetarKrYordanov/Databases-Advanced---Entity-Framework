namespace PhotoShare.Client.Core.Commands
{
    using System;

    using Contracts;
    using Services.Contracts;
    using Dtos;

    public class AddTagToCommand : ICommand
    {
        private readonly ITagService tagService;
        private readonly IAlbumService albumService;
        private readonly IAlbumTagService albumTagService;
        private readonly IUserSessionService userSessionService;
        private readonly IAlbumRoleService albumRoleService;
        public AddTagToCommand(ITagService tag,IAlbumService albumService,
            IAlbumTagService albumTagService,IUserSessionService userSessionService,IAlbumRoleService albumRoleService)
        {
            this.albumRoleService = albumRoleService;
            this.userSessionService = userSessionService;
            this.tagService = tag;
            this.albumService = albumService;
            this.albumTagService = albumTagService;
        }

        // AddTagTo <albumName> <tag>
        public string Execute(string[] args)
        {
            var albumName = args[0];
            var tag = args[1];

            if (!userSessionService.IsLoggedIn())
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            var username = userSessionService.User.Username;
            AlbumRoleDto roleDto = albumRoleService.GetAlbumOwner<AlbumRoleDto>(albumName, username);
            if (roleDto == null)
            {
                throw new InvalidOperationException("Invalid credentials!");
            }
            if (tagService.Exists(tag)==false &&albumService.Exists(albumName))
            {
                throw new ArgumentException("Either tag or album do not exist!");
            }
            var tagDto = tagService.ByName<TagDto>(tag);
            var albumDto = albumService.ByName<AlbumDto>(albumName);
            albumTagService.AddTagTo(albumDto.Id, tagDto.Id);

            var result = $"Tag {tag} added to {albumName}!";
            return result;
        }
    }
}
