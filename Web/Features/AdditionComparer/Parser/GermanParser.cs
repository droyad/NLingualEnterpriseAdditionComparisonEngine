using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.AdditionComparer.Parser
{
    [Language("de")]
    public class GermanParser : IParser
    {
        private readonly string[] _numbers = { "null", "eins", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun" };

        public Result<IReadOnlyCollection<int>> Parse(string input)
        {
            var results = input
                .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(GetNumber)
                .ToArray();

            return results.Then(n => (IReadOnlyCollection<int>) n.ToArray());
        }

        private Result<int> GetNumber(string s)
        {
            var index = Array.IndexOf(_numbers, s);
            if (index == -1)
                return Result<int>.Failed($"{s} is not a valid number in German");
            return index;
        }
    }
}