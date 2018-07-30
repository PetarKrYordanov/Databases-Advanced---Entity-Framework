namespace PhotoShare.Services
{
    using System.Linq;

    using Contracts;
    using PhotoShare.Models;
    using PhotoShare.Data;

    using AutoMapper.QueryableExtensions;

    public class TownService : ITownService
    {
        private readonly PhotoShareContext context;
        public TownService(PhotoShareContext context)
        {
            this.context = context;
        }
        public Town Add(string townName, string countryName)
        {
            var town = new Town() { Name = townName, Country = countryName };

            this.context.Towns.Add(town);
            this.context.SaveChanges();
            return town;
        }

        public TModel ById<TModel>(int id)
        {
            throw new System.NotImplementedException();
        }

        public TModel ByName<TModel>(string name)
        {
            TModel modelDto = this.context.Towns.Where(e => e.Name == name)
                            .ProjectTo<TModel>()
                            .FirstOrDefault();
            return modelDto;
        }

        public bool Exists(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(string name)
        {
            var townName = this.context.Towns.Any(x => x.Name == name);
            if (townName)
            {
                return true;
            }
            return false;
        }
    }
}
