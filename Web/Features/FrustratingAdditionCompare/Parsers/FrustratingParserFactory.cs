using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.FrustratingAdditionCompare.Parsers
{
    [SingleInstance]
    public class FrustratingParserFactory
    {
        private readonly Dictionary<string, IFrustratingParser> _parsers = new Dictionary<string, IFrustratingParser>(StringComparer.InvariantCultureIgnoreCase)
        {
            {"en", new Parser("en-AU", "zero","one","two","three","four","five","six","seven","eight","nine")},
            {"de", new Parser("de-DE", "null", "eins", "zwei", "drei", "vier", "fünf", "sechs", "sieben", "acht", "neun")}
        };


        public IFrustratingParser Get(string language)
        {
            IFrustratingParser parser;
            if (_parsers.TryGetValue(language, out parser))
                return parser;

            throw new Exception($"Language {language} is not supported");
        }

        private class Parser : IFrustratingParser
        {
            private readonly string _culture;
            private readonly string[] _numbers;

            public Parser(string culture, params string[] numbers)
            {
                _culture = culture;
                _numbers = numbers;
            }


            public IReadOnlyList<int> Parse(string input)
            {
                return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s =>
                {
                    var index = Array.IndexOf(_numbers, s);
                    if (index == -1)
                        throw new Exception($"{s} is not a valid number for culture {_culture}");
                    return index;
                })
                .ToArray();
            }
        }
    }
}