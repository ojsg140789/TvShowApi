using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TvShowApi.Application.DTOs;
using TvShowApi.Domain.Entities;

namespace TvShowApi.Application.Profiles
{
    public class TvShowProfile : Profile
    {
        public TvShowProfile() 
        {
            // Mapeo de TvShow a TvShowDto y viceversa
            CreateMap<TvShow, TvShowDto>().ReverseMap();
            // Mapeo de CreateTvShowDto a TvShow (sin Id)
            CreateMap<CreateTvShowDto, TvShow>();
        }
    }
}
