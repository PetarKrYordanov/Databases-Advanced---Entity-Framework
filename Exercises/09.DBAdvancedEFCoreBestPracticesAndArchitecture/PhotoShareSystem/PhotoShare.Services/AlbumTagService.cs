namespace PhotoShare.Services
{
    using Contracts;
    using PhotoShare.Data;
    using PhotoShare.Models;

    public class AlbumTagService : IAlbumTagService
    {
        private readonly PhotoShareContext context;
        public AlbumTagService(PhotoShareContext photoShareContext)
        {
            this.context = photoShareContext;
        }
        public AlbumTag AddTagTo(int albumId, int tagId)
        {
            AlbumTag albumTag = new AlbumTag() { AlbumId = albumId, TagId = tagId };
            this.context.AlbumTags.Add(albumTag);
            this.context.SaveChanges();
            return albumTag;
        }
    }
}
