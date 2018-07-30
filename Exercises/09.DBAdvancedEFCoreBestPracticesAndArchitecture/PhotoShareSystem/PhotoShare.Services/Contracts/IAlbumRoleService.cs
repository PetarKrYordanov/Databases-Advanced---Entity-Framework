namespace PhotoShare.Services.Contracts
{
    using Models;
    using Models.Enums;

    public interface IAlbumRoleService
    {
        AlbumRole PublishAlbumRole(int albumId, int userId, string role);

        TModel GetAlbumOwner<TModel>(string albumName, string Username);

    }
}
