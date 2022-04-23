using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DoctorWho.Db;
using DoctorWho.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Tests.Repositories;

public class ProcedureRepo
{
    [Fact]
    public async Task ShouldExecuteProcedure()
    {
        var _optionsBuilder = new DbContextOptionsBuilder<DoctorWhoDbContext>();
        _optionsBuilder.UseInMemoryDatabase("ExecutProcedure");
        using (var context = new DoctorWhoDbContext(_optionsBuilder.Options))
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            var result = await Procedures.ExecuteProcedure();
            Assert.Equal(3,result.Item1.Count());
            Assert.Equal(3,result.Item2.Count());
            foreach (var VARIABLE in result.Item1)
            {
                Assert.True((VARIABLE.CompanionId==1||VARIABLE.CompanionId==3||VARIABLE.CompanionId==4));
            }
            foreach (var VARIABLE in result.Item2)
            {
                Assert.True((VARIABLE.EnemyId==1||VARIABLE.EnemyId==3||VARIABLE.EnemyId==4));
            }
        }
    }
}