//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public static void specs(in RuleTableRow src, char kind, HashSet<RuleCellSpec> dst)
        {
            var storage = 0ul;
            var count = RuleTableRow.ColCount/2;
            var i = kind == 'P' ? z8 : count;
            var k = z8;
            for(var j=0; j<count; j++, i++)
            {
                var cell = src[i];
                if(cell.IsNonEmpty)
                    dst.Add(cell.Spec);
            }
        }
   }
}