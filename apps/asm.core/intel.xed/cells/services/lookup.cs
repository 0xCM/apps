// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        partial class RuleTables
        {
            public static ConstLookup<RuleSig,CellTable> lookup(CellTable[] tables)
                => tables.Select(x => (x.Sig,x)).ToDictionary();
        }
    }
}