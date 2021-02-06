using AutoMapper;
using Brainfinity.Data.Entities;
using Brainfinity.Domain.Dtos;
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
        }
    }
}