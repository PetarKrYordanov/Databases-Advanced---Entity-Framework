namespace PhotoShare.Services
{
    using System.Linq;

    using AutoMapper.QueryableExtensions;

    using Contracts;
    using PhotoShare.Models;
    using PhotoShare.Data;
    public class TagService : ITagService
    {
        private readonly PhotoShareContext context;
        public TagService(PhotoShareContext context)
        {
            this.context = context;
        }
        public Tag AddTag(string name)
        {
            var tag = new Tag() { Name = name };
            this.context.Tags.Add(tag);
            this.context.SaveChanges();
            return tag;
        }

        public TModel ById<TModel>(int id)
        {
            throw new System.NotImplementedException();
        }

        public TModel ByName<TModel>(string name)
        {
            TModel model = this.context.Tags.Where(e => e.Name == name).ProjectTo<TModel>().FirstOrDefault();
            return model;
        }

        public bool Exists(int id)
        {
            if (this.context.Tags.Any(x => x.Id == id))
            {
                return true;
            }
            return false;
        }

        public bool Exists(string name)
        {
            if (this.context.Tags.Any(x => x.Name == name))
            {
                return true;
            }
            return false;
        }
    }
}
