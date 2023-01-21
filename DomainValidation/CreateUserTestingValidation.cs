using MtGDomain.Models;

namespace DomainValidation
{
    [Trait("Domain", "Validation CreateUserValidating")]
    public class CreateUserTestingValidation
    {
        [Fact]
        public void CreateUser_WithAge4_ShouldNotBeValid()
        {
            CreateUser TestCode() => new CreateUser("Markus Nordin", 4);
            var exception = Assert.Throws<Exception>(TestCode);
        }

        [Fact]
        public void CreateUser_WithAge6_ShouldBeValid()
        {
            CreateUser cu = new("Markus Nordin", 6);
            Assert.True(6 == cu.GetAge);
        }

        [Fact]
        public void CreateUserWithRulesTest_SetAgeTo45_ModelShouldBeValid_ErrorsShouldBeZero()
        {
            CreateUserWithRules cu = new() { Name = "Markus Nordin", Age = 45 };
            Assert.True(cu.IsModelValid());
            Assert.True(cu.Errors.Count() == 0);
        }

        [Fact]
        public void CreateUserWithRulesTest_SetAgeTo4_ModelShouldNOTBeValid_ErrorsShouldBeOne()
        {
            CreateUserWithRules cu = new() { Name = "Markus Nordin",Age = 4 };
            Assert.False(cu.IsModelValid());
            Assert.True(cu.Errors.Count() == 1);
        }

    }
}