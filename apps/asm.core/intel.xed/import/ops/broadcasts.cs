//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static XedModels;
    using static core;

    partial class XedImport
    {
        static void broadcasts(out Index<AsmBroadcastDef> dst)
        {
            var kinds = Symbols.index<BCastKind>().Kinds;
            var count = kinds.Length;
            dst = alloc<AsmBroadcastDef>(count);
            for(var j=0; j<kinds.Length; j++)
                dst[j] = XedOperands.broadcast(skip(kinds,j));
        }
    }
}