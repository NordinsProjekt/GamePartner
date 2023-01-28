using MtGDomain.Exceptions;
using MtGDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestForSolution._0._4_Domain.Models
{
    [Trait("Domain", "MtGDamageObjekt")]
    public class MtGDamageObjekt_Test
    {
        [Fact]
        public void CreateDamageObject_WithBadPlayerIdNumber_ShouldThrowException()
        {
            var result = Assert.Throws<DamageException>(() => new MtGDamageObject(1, -1, MtGDomain.Enums.TypeOfUnit.Heal));
            Assert.NotNull(result);
            Assert.Equal("PlayerId not accepted", result.Message);
        }

        [Fact]
        public void CreateDamageObject_With0Amount_ShouldThrowException()
        {
            var result = Assert.Throws<DamageException>(() => new MtGDamageObject(0, 1, MtGDomain.Enums.TypeOfUnit.Heal));
            Assert.NotNull(result);
            Assert.Equal("Amount cant be zero or below", result.Message);
        }

        [Fact]
        public void CreateDamageObject_WithNegative1Amount_ShouldThrowException()
        {
            var result = Assert.Throws<DamageException>(() => new MtGDamageObject(-1, 1, MtGDomain.Enums.TypeOfUnit.Heal));
            Assert.NotNull(result);
            Assert.Equal("Amount cant be zero or below", result.Message);
        }
    }
}
