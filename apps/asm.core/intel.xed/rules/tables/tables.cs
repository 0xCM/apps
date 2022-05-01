//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        partial class RuleTables
        {
            public static Index<RuleCell> flatten(RuleCells src)
                => src.Values.ToArray().Index().Select(v => (v.Index().Select(x => x))).SelectMany(x => x).Sort();
        }
    }
}