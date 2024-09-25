using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowApi.Application.DTOs;
using TvShowApi.Domain.Entities;

namespace TvShowApi.Application.Interfaces
{
    public interface ITvShowService
    {
        IEnumerable<TvShowDto> GetAllTvShows();
        TvShowDto GetTvShowById(int id);
        void CreateTvShow(CreateTvShowDto tvShowDto);
        void UpdateTvShow(int id, TvShowDto tvShowDto);
        void DeleteTvShow(int id);
    }
}
