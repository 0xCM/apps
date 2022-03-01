//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static RuleSig sig(in RuleTable src)
            => new RuleSig(src.Name, src.ReturnType.IsNonEmpty ? src.ReturnType.Text : "void");
    }
}