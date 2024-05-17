﻿using AutoMapper;
using FilmesApi.Data.Dto;
using FilmesApi.Models;

namespace FilmesApi.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            CreateMap<Sessao, ReadSessaoDto>()
                .ForMember(sessaoDto => sessaoDto.Filme,
                opt => opt.MapFrom(sessao => sessao.Filme));
        }
    }
}
