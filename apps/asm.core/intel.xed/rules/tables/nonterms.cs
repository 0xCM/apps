//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static DataStores;

    partial class XedRules
    {
        public static S16<Nonterminal> nonterms(Index<CellInfo> src)
        {
            var Capacity = count16<Nonterminal>();
            var dst = alloc16<Nonterminal>((int)src.Count);
            var j=0;
            for(var i=0; i<src.Count && j<Capacity; i++)
            {
                ref readonly var data = ref src[i].Data;
                if(XedParsers.IsNonterm(data))
                {
                    if(XedParsers.parse(data, out Nonterminal nt))
                        dst[j++] = nt;
                }
            }
            return dst;
        }
    }
}