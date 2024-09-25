using AutoMapper;
using TvShowApi.Application.DTOs;
using TvShowApi.Application.Interfaces;
using TvShowApi.Domain.Entities;
using TvShowApi.Domain.Repositories;

namespace TvShowApi.Application.Services
{
    public class TvShowService : ITvShowService
    {
        private readonly ITvShowRepository _repository;
        private readonly IMapper _mapper;

        public TvShowService(ITvShowRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<TvShowDto> GetAllTvShows() 
        {
            var tvShows = _repository.GetAll();
            return _mapper.Map<IEnumerable<TvShowDto>>(tvShows);
        }

        public TvShowDto GetTvShowById(int id)
        {
            var tvShow = _repository.GetById(id);
            return _mapper.Map<TvShowDto>(tvShow);
        }

        public void CreateTvShow(CreateTvShowDto createTvShowDto)
        {
            var tvShow = _mapper.Map<TvShow>(createTvShowDto);
            _repository.Add(tvShow);
        }

        public void UpdateTvShow(int id, TvShowDto tvShowDto)
        {
            var existingShow = _repository.GetById(id);
            if (existingShow != null)
            {
                var updatedShow = _mapper.Map(tvShowDto, existingShow);
                _repository.Update(updatedShow);
            }
            else
            {
                throw new ArgumentException("El show no existe.");
            }
        }

        public void DeleteTvShow(int id) => _repository.Delete(id);
    }
}