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
    }
}