using TvShowApi.Application.DTOs;
using TvShowApi.Application.Interfaces;
using TvShowApi.Domain.Entities;
using TvShowApi.Domain.Repositories;

namespace TvShowApi.Application.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly ITvShowRepository _repository;

        public TvShowService(ITvShowRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<TvShow> GetAllTvShows() => _repository.GetAll();

        public TvShow GetTvShowById(int id) => _repository.GetById(id);

        public void CreateTvShow(TvShowDto tvShowDto)
        {
            var tvShow = new TvShow
            {
                Name = tvShowDto.Name,
                Favorite = tvShowDto.Favorite
            };
            _repository.Add(tvShow);
        }

        public void UpdateTvShow(int id, TvShowDto tvShowDto)
        {
            var tvShow = new TvShow
            {
                Id = id,
                Name = tvShowDto.Name,
                Favorite = tvShowDto.Favorite
            };
            _repository.Update(tvShow);
        }

        public void DeleteTvShow(int id) => _repository.Delete(id);
    }
}