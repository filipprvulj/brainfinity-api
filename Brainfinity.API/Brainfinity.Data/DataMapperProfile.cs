﻿using AutoMapper;
using Brainfinity.Data.Entities;
using Brainfinity.Domain.Dtos;
using Brainfinity.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data
{
    public class DataMapperProfile : Profile
    {
        public DataMapperProfile()
        {
            #region Competition maps

            CreateMap<Competition, CompetitionDto>()
                .ReverseMap()
                .ForMember(d => d.Users, opt => opt.MapFrom(s => s.Teams));

            #endregion Competition maps

            #region User registration maps

            CreateMap<TeamMember, TeamMemberDto>().ReverseMap();
            CreateMap<TeamMentor, TeamMentorDto>().ReverseMap();
            CreateMap<User, TeamDto>().ReverseMap();
            CreateMap<RegisterTeamModel, TeamDto>()
                .ForMember(d => d.Logo, opt => opt.Ignore())
                .ForMember(d => d.TeamPicture, opt => opt.Ignore())
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.Email));
            CreateMap<TeamMemberModel, TeamMemberDto>();
            CreateMap<TeamMentorModel, TeamMentorDto>();

            #endregion User registration maps

            #region User login maps

            CreateMap<User, UserDto>().ReverseMap();

            #endregion User login maps

            #region Team maps

            CreateMap<User, TeamOutputModel>()
                .ForMember(d => d.Mentor, opt => opt.MapFrom(s =>
                    string.Join(" ", s.TeamMentor.FirstName, s.TeamMentor.LastName)))
                .ForMember(d => d.Grade, opt => opt.MapFrom(s =>
                    string.Join(" - ", s.Grade.GradeLevel.GradeLevelName, s.Grade.Name)));

            #endregion Team maps
        }
    }
}