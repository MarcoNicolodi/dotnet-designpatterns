using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Rules.LinqExtensions;

namespace Rules
{



    public interface IDiceRoll
    {
        int GetValue();
    }

    public class DiceRoll : IDiceRoll
    {
        private int Value { get; }

        protected DiceRoll(int value)
        {
            Validate(value);
            Value = value;
        }

        public static DiceRoll Create()
        {
            return new DiceRoll(new Random().Next(1, 6));
        }

        public int GetValue()
        {
            return Value;
        }

        private void Validate(int value)
        {
            if (value < 1 || value > 6) throw new Exception("Only 6 sides dices allowed");
        }

    }

    public interface IDiceRollProvider
    {
        ReadOnlyCollection<IDiceRoll> Roll();
    }

    public class FiveDiceRollsProvider : IDiceRollProvider
    {
        public ReadOnlyCollection<IDiceRoll> Roll()
        {
            return (new List<IDiceRoll>()
            {
                DiceRoll.Create(),
                DiceRoll.Create(),
                DiceRoll.Create(),
                DiceRoll.Create(),
                DiceRoll.Create()
            }).AsReadOnly();
        }
    }

    public class Match
    {

        private readonly IDiceRollProvider _diceRollProvider;

        public ReadOnlyCollection<IDiceRoll> Rolls { get; private set; }

        public Match(IDiceRollProvider provider)
        {
            _diceRollProvider = provider;
        }

        public Match Play()
        {
            Rolls = _diceRollProvider.Roll();

            return this;
        }

        public int GetScore()
        {
            if (Rolls.Count != 0)
                return new MatchEvaluator(this).GetScore();

            return 0;
        }
    }

    public interface IRule
    {
        bool IsMatch();
        int Evaluate(Match match);
    }

    public class SingleOnes : IRule
    {
        private readonly Match _match;

        public SingleOnes(Match match)
        {
            _match = match;
        }

        public bool IsMatch()
        {
            return true;
            // 1,1,1,4,1
            // 1,1,1,4,4
            // 1,1,1,1,1
            // 1,4,1,1,1
            // 4,1,1,1,1
            // not followed by previous two
            // followed by previous three
            // followed by previous four
            // 
        }

        public int Evaluate(Match match)
        {
            var onesGroups = match
                .Rolls
                .GroupWhile((prev, cur) => cur.GetValue() == 1 && prev.GetValue() == cur.GetValue());


            var singleOnes = onesGroups.Count(r => r.Count() == 1);

            return IsMatch() ? _match.Rolls.Count(r => r.GetValue() == 1) * 50 : 0;
        }
    }

    public class TripleOnes : IRule
    {
        private readonly Match _match;

        public TripleOnes(Match match)
        {
            _match = match;
        }
        public int Evaluate(Match match)
        {
            if (IsMatch())
                return 1000;

            return 0;
        }

        public bool IsMatch()
        => _match
            .Rolls
            .GroupWhile((prev, cur) => cur.GetValue() == 1 && cur.GetValue() == prev.GetValue())
            .Where(s => s.Count() >= 3).Count() > 0;



    }

    public class MatchEvaluator
    {
        private readonly Match _match;
        private List<IRule> _rules = new List<IRule>();

        public MatchEvaluator(Match match)
        {
            _match = match;
            _rules.Add(new SingleOnes(_match));
            _rules.Add(new TripleOnes(_match));
        }

        public int GetScore() => _rules.Sum(r => r.Evaluate(_match));

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
