using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.AdditionComparer.Parser
{
    [Language("en")]
    public class EnglishParser : IParser
    {
        private readonly string[] _numbers = { "zero","one","two","three","four","five","six","seven","eight","nine"};

        public Result<IReadOnlyCollection<int>> Parse(string input)
        {
            var results = input
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(GetNumber)
                .ToArray();

            return results.Then(n => (IReadOnlyCollection<int>)n.ToArray());
        }

        private Result<int> GetNumber(string s)
        {
            var index = Array.IndexOf(_numbers, s);
            if (index == -1)
                return Result<int>.Failed($"{s} is not a valid number in English");
            return index;
        }
    }
}