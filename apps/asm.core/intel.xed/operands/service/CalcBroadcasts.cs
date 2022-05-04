//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using static XedModels;
    using static core;

    partial class XedOperands
    {
        static Index<BroadcastDef> CalcBroadcasts()
        {
            var kinds = Symbols.index<BCastKind>().Kinds;
            var count = kinds.Length;
            var defs = alloc<BroadcastDef>(count);
            for(var j=0; j<kinds.Length; j++)
                seek(defs,j) = broadcast(skip(kinds,j));
            return defs;
        }
    }
}