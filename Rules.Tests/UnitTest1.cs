using System;
using Xunit;
using Rules;
using Moq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Rules.Tests
{
    internal class MutableDiceRoll : IDiceRoll
    {
        private int Value;

        public MutableDiceRoll(int value)
        {
            Value = value;
        }

        public int GetValue() => Value;

    }

    public class UnitTest1
    {
        class DiceRollsBuilder
        {
            private List<IDiceRoll> _rolls = new List<IDiceRoll>();

            public ReadOnlyCollection<IDiceRoll> Build()
            {
                return _rolls.AsReadOnly();
            }
            public DiceRollsBuilder WithValue(int value)
            {
                _rolls.Add(new MutableDiceRoll(value));
                return this;
            }
        }

        [Fact]
        public void SingleOnes_ShouldScore50PointsForEachRoll()
        {
            var diceRollBuilder = new DiceRollsBuilder();
            var singleOnes = diceRollBuilder
                .WithValue(1)
                .WithValue(2)
                .WithValue(1)
                .WithValue(1)
                .WithValue(3)
                .Build();


            var diceRollProvider = new Mock<IDiceRollProvider>();
            diceRollProvider.Setup(d => d.Roll()).Returns(singleOnes);
            var match = new Match(diceRollProvider.Object);
            match.Play();
            Assert.Equal(150, match.GetScore());
        }

        [Fact]
        public void TripleOnes_ShouldScore1000Points()
        {
            var diceRollBuilder = new DiceRollsBuilder();
            var singleOnes = diceRollBuilder
                .WithValue(1)
                .WithValue(1)
                .WithValue(1)
                .WithValue(2)
                .WithValue(3)
                .Build();

            var diceRollProvider = new Mock<IDiceRollProvider>();
            diceRollProvider.Setup(d => d.Roll()).Returns(singleOnes);
            var match = new Match(diceRollProvider.Object);
            match.Play();
            Assert.Equal(1000, match.GetScore());
        }

        [Fact]
        public void SingleOnesShouldIgnoreTripleOnesWhenScoring()
        {
            var diceRollBuilder = new DiceRollsBuilder();
            var singleOnes = diceRollBuilder
                .WithValue(1)
                .WithValue(1)
                .WithValue(1)
                .WithValue(1)
                .WithValue(1)
                .Build();

            var diceRollProvider = new Mock<IDiceRollProvider>();
            diceRollProvider.Setup(d => d.Roll()).Returns(singleOnes);
            var match = new Match(diceRollProvider.Object);
            match.Play();
            Assert.Equal(1100, match.GetScore());
        }
    }
}
