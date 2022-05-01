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
            public static Index<RuleCell> flat(Pairings<RuleSig,Index<RuleCell>> src)
                => src.Array().SelectMany(x => x.Right).Sort();
        }
    }
}