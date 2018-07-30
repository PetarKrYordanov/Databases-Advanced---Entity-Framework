namespace PhotoShare.Services
{
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using Contracts;
    using PhotoShare.Models;
    using PhotoShare.Models.Enums;
    using PhotoShare.Data;

    public class AlbumService : IAlbumService
    {
        private readonly PhotoShareContext context;
       
        public AlbumService(PhotoShareContext photoShareContext)
        {
            this.context = photoShareContext;
        }
        public TModel ById<TModel>(int id)
        {
            TModel model = this.context.Albums
                        .Where(x => x.Id == id)
                        .ProjectTo<TModel>()
                        .FirstOrDefault();
            return model;
        }

        public TModel ByName<TModel>(string name)
        {
            TModel model = this.context.Albums
                         .Where(x => x.Name == name)
                         .ProjectTo<TModel>()
                         .FirstOrDefault();
            return model;
        }

        public Album Create(int userId, string albumTitle, Color BgColor, string[] tags)
        {
    
            var album = new Album() { Name = albumTitle, BackgroundColor = BgColor };
            this.context.Albums.Add(album);
            this.context.SaveChanges();
            var id = this.context.Albums.Where(e => e.Name == albumTitle).Select(x => x.Id).First();

            AlbumTagService albumTagService = new AlbumTagService(this.context);
            TagService tagService = new TagService(this.context);

            for (int i = 0; i < tags.Length; i++)
            {
                var currentTag = tagService.ByName<Tag>(tags[i]);
                albumTagService.AddTagTo(id, currentTag.Id);
            }

            AlbumRoleService roleService = new AlbumRoleService(this.context);
            AlbumRole albumRole = new AlbumRole() { AlbumId = id, UserId = userId };
            this.context.AlbumRoles.Add(albumRole);
            this.context.SaveChanges();
            return album;
        }

        public bool Exists(int id)
        {
            if (this.context.Albums.Any(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

        public bool Exists(string name)
        {
            if (this.context.Albums.Any(x => x.Name == name))
            {
                return true;
            }
            return false;
        }
    }
}
