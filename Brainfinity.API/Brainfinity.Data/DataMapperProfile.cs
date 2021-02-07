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

            CreateMap<Competition, CompetitionDto>().ReverseMap();

            #endregion Competition maps

            #region User registration maps

            CreateMap<TeamMember, TeamMemberDto>().ReverseMap();
            CreateMap<User, TeamDto>().ReverseMap();
            CreateMap<RegisterTeamModel, TeamDto>()
                .ForMember(d => d.Logo, opt => opt.Ignore())
                .ForMember(d => d.TeamPicture, opt => opt.Ignore());
            CreateMap<TeamMemberModel, TeamMemberDto>();

            #endregion User registration maps

            #region User login maps

            CreateMap<User, UserDto>().ReverseMap();

            #endregion User login maps
            #region AssignmentGroup maps

            CreateMap<AssignmentGroup, AssignmentGroupDto>().ReverseMap();

            #endregion AssignmentGroup maps

            #region Assigmnent maps

            CreateMap<Assignment, AssignmentDto>().ReverseMap();

            #endregion Assignment maps
        }
    }
}