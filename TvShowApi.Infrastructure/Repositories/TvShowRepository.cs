using TvShowApi.Domain.Entities;
using TvShowApi.Domain.Repositories;

namespace TvShowApi.Infrastructure.Repositories
{
    public class TvShowRepository : ITvShowRepository
    {
        private readonly List<TvShow> _tvShows;

        public TvShowRepository()
        {
            // Datos iniciales
            _tvShows = new List<TvShow>
            {
                new TvShow { Id = 1, Name = "Breaking Bad", Favorite = true },
                new TvShow { Id = 2, Name = "Game of Thrones", Favorite = false },
                new TvShow { Id = 3, Name = "Stranger Things", Favorite = true }
            };
        }

        public IEnumerable<TvShow> GetAll() => _tvShows;

        public TvShow GetById(int id) => _tvShows.FirstOrDefault(show => show.Id == id);

        public void Add(TvShow tvShow)
        {
            tvShow.Id = _tvShows.Select(show => show.Id).DefaultIfEmpty(0).Max() + 1;
            _tvShows.Add(tvShow);
        }

        public void Update(TvShow tvShow)
        {
            var existingShow = GetById(tvShow.Id);
            if (existingShow != null)
            {
                existingShow.Name = tvShow.Name;
                existingShow.Favorite = tvShow.Favorite;
            }
        }

        public void Delete(int id) => _tvShows.RemoveAll(show => show.Id == id);
    }
}
