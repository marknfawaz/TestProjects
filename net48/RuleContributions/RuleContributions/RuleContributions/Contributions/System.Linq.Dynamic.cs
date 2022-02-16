using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;

namespace RuleContributions.Contributions
{
    public class DynamicQuery
    {
        private static void SampleDynamicLinqCall()
        {
            var list = new List<string>();
            var dynamicQueryResult = list.AsQueryable()
                .Where("Name.Contains(@0)", "SomeSubstring")
                .ToList();
        }
    }
}