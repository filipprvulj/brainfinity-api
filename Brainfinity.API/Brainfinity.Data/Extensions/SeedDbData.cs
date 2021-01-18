using Brainfinity.Data.Entities;
using Brainfinity.Domain.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brainfinity.Data.Extensions
{
    public static class SeedDbData
    {
        public static void SeedStatuses(this ModelBuilder builder)
        {
            builder.Entity<Status>().HasData(
                new Status { Id = Guid.Parse("8f9602ac-a032-4608-9764-96b6e447c43f"), StatusName = StatusNames.Aktivno },
                new Status { Id = Guid.Parse("4933b1c4-9a18-437c-87f3-92f4c11caacf"), StatusName = StatusNames.Nadolazece },
                new Status { Id = Guid.Parse("c68e06ad-d0d2-49c2-9f7a-a04ea52bcccd"), StatusName = StatusNames.Zavrseno }
                );
        }

        public static void SeedGradeLevels(this ModelBuilder builder)
        {
            builder.Entity<GradeLevel>().HasData(
                new GradeLevel { Id = Guid.Parse("9b46dc05-75f8-49d8-a09d-19894e0c76a4"), GradeLevelName = GradeLevelNames.OsnovnaSkola },
                new GradeLevel { Id = Guid.Parse("a251c876-81ce-4299-820d-ffc7a31fe436"), GradeLevelName = GradeLevelNames.SrednjaSkola }
                );
        }

        public static void SeedGrade(this ModelBuilder builder) 
        {
            builder.Entity<Grade>().HasData(
                new Grade
                {
                    Id = Guid.Parse("595375E5-C4A7-7A51-7DEB-3EF7C0D65B62"),
                    GradeLevelId = Guid.Parse("9b46dc05-75f8-49d8-a09d-19894e0c76a4"),
                    Name = "5. razred"
                },

                new Grade
                {
                    Id = Guid.Parse("590A46CB-7104-9F85-8706-FD2142EA12E6"),
                    GradeLevelId = Guid.Parse("9b46dc05-75f8-49d8-a09d-19894e0c76a4"),
                    Name = "6. razred"
                },

                new Grade
                {
                    Id = Guid.Parse("48EC597E-A374-DC80-6A95-A2792CA27DB1"),
                    GradeLevelId = Guid.Parse("9b46dc05-75f8-49d8-a09d-19894e0c76a4"),
                    Name = "7. razred"
                },

                new Grade
                {
                    Id = Guid.Parse("24BC1870-6DF9-83AC-8937-58E12D02036C"),
                    GradeLevelId = Guid.Parse("9b46dc05-75f8-49d8-a09d-19894e0c76a4"),
                    Name = "8. razred"
                },

                new Grade
                {
                    Id = Guid.Parse("543B42FC-D3EC-90EB-2782-C3BF0B0E182A"),
                    GradeLevelId = Guid.Parse("a251c876-81ce-4299-820d-ffc7a31fe436"),
                    Name = "1. razred"
                },

                new Grade
                {
                    Id = Guid.Parse("E3EB45E7-E68B-10D1-286B-6D0F7145F10A"),
                    GradeLevelId = Guid.Parse("a251c876-81ce-4299-820d-ffc7a31fe436"),
                    Name = "2. razred"
                },

                 new Grade
                 {
                     Id = Guid.Parse("BA1A5AC3-D30E-8073-A642-3806E7F13E78"),
                     GradeLevelId = Guid.Parse("a251c876-81ce-4299-820d-ffc7a31fe436"),
                     Name = "3. razred"
                 },

                  new Grade
                  {
                      Id = Guid.Parse("F3B1C158-E9B2-CA45-E9C3-B6A0130FD257"),
                      GradeLevelId = Guid.Parse("a251c876-81ce-4299-820d-ffc7a31fe436"),
                      Name = "4. razred"
                  }
                );    
        } 
    }
}