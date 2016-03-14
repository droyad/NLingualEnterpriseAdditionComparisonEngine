using System;
using Autofac;
using FluentAssertions;
using NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare;
using NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare.Parsers;
using NLingualEnterpriseAdditionComparisonEngine.Web.Plumbing;
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

            result.WasSuccessful.Should().BeTrue();
            result.Value.Should().Be(CompareResult.Same);
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

            result.WasSuccessful.Should().BeTrue();
            result.Value.Should().Be(CompareResult.Different);
        }

        [Test]
        public void InvalidLanguageAndNumber()
        {
            var input = new[]
            {
                new Model() {Language = "en", Additions = "one two foo"},
                new Model() {Language = "zu", Additions = "kunye kubile kuthathu"}
            };

            var result = Execute(input);

            result.WasSuccessful.Should().BeFalse();
            result.Errors.Length.Should().Be(2);
            result.Errors.Should().Contain("Language zu is not supported");
            result.Errors.Should().Contain("foo is not a valid number in English");
        }

        private static Result<CompareResult> Execute(Model[] input)
        {
            var result = IoC.Incorporate().Resolve<AdditionComparer>()
                .Compare(input);
            return result;
        }
    }
}