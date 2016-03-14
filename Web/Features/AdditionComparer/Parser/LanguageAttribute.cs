using System;

namespace NLingualEnterpriseAdditionComparisonEngine.Web.Features.AdditionComparer.Parser
{
    public class LanguageAttribute : Attribute
    {
        public string Name { get; set; }

        public LanguageAttribute(string name)
        {
            Name = name;
        }
    }
}