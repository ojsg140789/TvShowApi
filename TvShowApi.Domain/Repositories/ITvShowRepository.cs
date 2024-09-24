using TvShowApi.Domain.Entities;

namespace TvShowApi.Domain.Repositories
{
    public interface ITvShowRepository
    {
        IEnumerable<TvShow> GetAll();
        TvShow GetById(int id);
        void Add(TvShow tvShow);
        void Update(TvShow tvShow);
        void Delete(int id);
    }
}
