using System;
using System.Collections.Generic;
using FluentAssertions;
using NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare.Parsers;
using NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing;
using NUnit.Framework;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare.Tests
{
    public class FrustratingAdditionComparerTests
    {
        [Test]
        public void ValidAndSame()
        {
            var input = new[]
            {
                new Model() {Language = "en", Additions = "one two three"},
                new Model() {Language = "de", Additions = "eins zwei drei"}
            };

            var result = Execute(input);

            result.Should().BeTrue();
        }


        [Test]
        public void ValidAndDifferent()
        {
            var input = new[]
            {
                new Model() {Language = "en", Additions = "one two"},
                new Model() {Language = "de", Additions = "eins zwei drei"}
            };

            var result = Execute(input);

            result.Should().BeFalse();
        }

        [Test]
        public void InvalidLanguageAndNumber()
        {
            var input = new[]
            {
                new Model() {Language = "en", Additions = "one two foo"},
                new Model() {Language = "zu", Additions = "kunye kubile kuthathu"}
            };

            var execute = (Action) (() => Execute(input));

            execute.ShouldThrow<Exception>().WithMessage("foo is not a valid number for culture en-AU");
        }

        private static bool Execute(Model[] input)
        {
            var result = new FrustratingAdditionComparer(new FrustratingParserFactory())
                .Compare(input);
            return result;
        }
    }
}