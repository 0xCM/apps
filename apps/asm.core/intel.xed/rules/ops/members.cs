//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Linq;

    using static XedModels;

    partial class XedRules
    {
        public static Index<InstGroupSeq> resequence(Index<InstGroupSeq> src)
        {
            var dst = src.Sort(new PatternOrder(true));
            for(var i=0u; i<dst.Count; i++)
                dst[i].Seq = i;
            return dst;
        }

        public static Dictionary<OpCodeClass,Index<InstGroupMember>> members(Index<InstGroup> src)
            => src.SelectMany(x => x.Members).GroupBy(x => x.Map.Class).Select(x => (x.Key, x.Index())).ToDictionary();

        public static Dictionary<OpCodeClass,Index<InstGroupSeq>> seq(Index<InstGroup> src)
            => src.SelectMany(x => x.Members.Select(x => x.Seq)).GroupBy(x => x.OpCodeClass).Select(x => (x.Key, x.Index())).ToDictionary();
    }
}