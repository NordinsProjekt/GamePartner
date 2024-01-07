using Infrastructure.MtGCard_API;
using MtGDomain.Models;

namespace UnitTestForSolution._0._2_Infrastructure
{
    [Trait("Infrastructure", "MappingFunctions")]
    public class MappingFunctionsTests
    {
        [Fact]
        public void CloneMtGRecord_ShouldNotBeEqual()
        {
            var card = new MtGCardObject() { Name = "TestCard1"}.GetDTO();
            var clone = MappingFunctions.CloneMtGRecord(card);

            Assert.NotEqual(card, clone);
        }

        [Fact]
        public void CloneMtgGRecord_ValuesShouldBeEqual()
        {
            var card = new MtGCardObject() { Name = "TestCard1" }.GetDTO();
            var clone = MappingFunctions.CloneMtGRecord(card);

            Assert.Equal(card.Name, clone.Name);
        }
    }
}
