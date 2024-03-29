﻿using MtGDomain.DTO;
using MtGDomain.Models;
using Portal.Extensions;

namespace UnitTestForSolution._0._1_Presentation.Extensions
{
    [Trait("Presentation", "DeckListExtensions")]
    public class DeckListExtensionsTests
    {
        [Fact]
        public void AddCardToDeck_AddCardToDeck_ShouldAddCardToList()
        {
            List<MtGDeckCard> list = new List<MtGDeckCard>();
            var card = new MtGCardObject() { Name = "TestCard1" }.GetDTO();

            list.AddCardToDeck(card, 1, MtGDomain.Enums.CardLocation.Main);

            Assert.True(list.Count == 1);
        }

        [Fact]
        public void AddCardToDeck_AddCardToDeck_CardAlreadyExistWithAmount_One_CardInListShouldHaveAmount_Two()
        {
            List<MtGDeckCard> list = new List<MtGDeckCard>()
            {
                new(){ Amount = 1, Card = new MtGCardObject() { Name = "TestCard1",  }.GetDTO() }
            };

            var card = new MtGCardObject() { Name = "TestCard1" }.GetDTO();

            list.AddCardToDeck(card, 1, MtGDomain.Enums.CardLocation.Main);
            var result = list.First(x=>x.Card.Name.Equals("TestCard1"));

            Assert.True(list.Count == 1);
            Assert.Equal(2, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_MaximumCardAllowedShouldBeFour_IfNotBasicLands_ShouldEqualToFour()
        {
            List<MtGDeckCard> list = new List<MtGDeckCard>()
            {
                new(){ Amount = 2, Card = new MtGCardObject() { Name = "TestCard1",  }.GetDTO() }
            };
            var card = new MtGCardObject() {  Name = "TestCard1" }.GetDTO();

            list.AddCardToDeck(card, 3, MtGDomain.Enums.CardLocation.Main);
            var result = list.First(x => x.Card.Name.Equals("TestCard1"));

            Assert.True(list.Count == 1);
            Assert.Equal(4, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardsMultipleTimes_IfNotBasicLands_ShouldEqualToFour()
        {
            List<MtGDeckCard> list = new List<MtGDeckCard>()
            {
                new(){ Amount = 2, Card = new MtGCardObject() { Name = "TestCard1",  }.GetDTO() }
            };
            var card = new MtGCardObject() {  Name = "TestCard1" }.GetDTO();

            list.AddCardToDeck(card, 1, MtGDomain.Enums.CardLocation.Main);
            list.AddCardToDeck(card, 1, MtGDomain.Enums.CardLocation.Main);
            list.AddCardToDeck(card, 1, MtGDomain.Enums.CardLocation.Main);
            var result = list.First(x => x.Card.Name.Equals("TestCard1"));

            Assert.True(list.Count == 1);
            Assert.Equal(4, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardsToDeck_IfBasicLands_ShouldEqualTo24()
        {
            List<MtGDeckCard> list = new List<MtGDeckCard>()
            {
                new(){ Amount = 2, Card = new MtGCardObject() { Name = "TestCard1",SuperTypes = new string[] { "Basic" }  }.GetDTO() }
            };
            var card = new MtGCardObject() { Name = "TestCard1", 
                SuperTypes = new string[] { "Basic" } }.GetDTO();

            list.AddCardToDeck(card, 22, MtGDomain.Enums.CardLocation.Main);
            var result = list.First(x => x.Card.Name.Equals("TestCard1"));

            Assert.True(list.Count == 1);
            Assert.Equal(24, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardToEmptyDeckList_IfBasicLands_ShouldEqualTo24()
        {
            List<MtGDeckCard> list = new List<MtGDeckCard>();

            var card = new MtGCardObject()
            {
                Name = "TestCard1",
                SuperTypes = new string[] { "Basic" }
            }.GetDTO();

            list.AddCardToDeck(card, 24, MtGDomain.Enums.CardLocation.Main);
            var result = list.First(x => x.Card.Name.Equals("TestCard1"));

            Assert.True(list.Count == 1);
            Assert.Equal(24, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardToEmptyDeckList_ShouldEqualTo1()
        {
            List<MtGDeckCard> list = new List<MtGDeckCard>();

            var card = new MtGCardObject()
            {
                Name = "TestCard1",
            }.GetDTO();

            list.AddCardToDeck(card, 1, MtGDomain.Enums.CardLocation.Main);
            var result = list.First(x => x.Card.Name.Equals("TestCard1"));

            Assert.True(list.Count == 1);
            Assert.Equal(1, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardToEmptyDeckList_ShouldEqualTo2()
        {
            List<MtGDeckCard> list = new List<MtGDeckCard>();

            var card = new MtGCardObject()
            {
                Name = "TestCard1",
            }.GetDTO();

            list.AddCardToDeck(card, 2, MtGDomain.Enums.CardLocation.Main);
            var result = list.First(x => x.Card.Name.Equals("TestCard1"));

            Assert.True(list.Count == 1);
            Assert.Equal(2, result.Amount);
        }

        [Fact]
        public void AddCardToDeck_AddingCardToEmptyDeckList_ShouldEqualTo3()
        {
            List<MtGDeckCard> list = new List<MtGDeckCard>();

            var card = new MtGCardObject()
            {
                Name = "TestCard1",
            }.GetDTO();

            list.AddCardToDeck(card, 3, MtGDomain.Enums.CardLocation.Main);
            var result = list.First(x => x.Card.Name.Equals("TestCard1"));

            Assert.True(list.Count == 1);
            Assert.Equal(3, result.Amount);
        }

        [Fact]
        public void CheckLegality_SendInListWithCards_GetListOfLegalFormats_ShouldReturnList()
        {
            List<MtGDeckCard> list = new List<MtGDeckCard>()
            {
                new MtGDeckCard()
                { Amount = 3, Card =  new MtGCardObject() { Name = "TestCard1", Legalities =  new List<MtGLegality>()
                { new MtGLegality("Standard","Legal"),new MtGLegality("Modern","Legal")}}
                .GetDTO()},

                { new MtGDeckCard()
                { Amount = 3, Card =  new MtGCardObject() { Name = "TestCard2", Legalities =  new List<MtGLegality>()
                { new MtGLegality("Standard","Legal"),new MtGLegality("Modern","Legal"),new MtGLegality("Vintage","Legal")}}
                .GetDTO()}} };

            var result = list.CheckLegality();

            Assert.Equal(2, result.Count);
        }
    }
}
