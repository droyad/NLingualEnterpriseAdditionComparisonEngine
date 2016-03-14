using System;
using FluentAssertions;
using NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare;
using NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare.Parsers;
using NUnit.Framework;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.AdditionComparer.Tests
{
    public class AdditionComparerTests
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

            result.Should().Be(true);
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

            result.Should().Be(false);
        }

        [Test]
        public void InvalidLanguage()
        {
            var input = new[]
            {
                new Model() {Language = "en", Additions = "one two"},
                new Model() {Language = "zu", Additions = "kunye kubile kuthathu"}
            };

            var execute = (Action) (() => Execute(input));

            execute.ShouldThrow<Exception>().WithMessage("Language zu is not supported");
        }

        private static bool Execute(Model[] input)
        {
            var result = new AdditionComparer(new FrustratingParserFactory())
                .Compare(input);
            return result;
        }
    }
}