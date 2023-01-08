using MtGDomain.Exceptions;
using MtGDomain.Models;
using Xunit.Sdk;

namespace UnitTest_MtGDomain
{
    [Trait("Domain", "ValidationTests")]
    public class DomainModelsValidationTests
    {
        [Fact]
        public void CreateDamageObject_WithBadPlayerIdNumber_ShouldThrowException()
        {
            var result = Assert.Throws<DamageException>(() => new MtGDamageObject(1, -1, MtGDomain.Enums.TypeOfUnit.Heal));
            Assert.NotNull(result);
            Assert.Equal("PlayerId not accepted",result.Message);
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