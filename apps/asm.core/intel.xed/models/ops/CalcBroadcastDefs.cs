//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static XedModels;
    using static core;

    partial class IntelXed
    {
        void EmitBroadcastDefs()
            => TableEmit(BcastDefs().View, BroadcastDef.RenderWidths, AppDb.XedTable<BroadcastDef>());

        [MethodImpl(Inline), Op]
        public static Index<BroadcastDef> BcastDefs()
            => _BroadcastDefs;

        static Index<BroadcastDef> bcastdefs()
        {
            var kinds = Symbols.index<BCastKind>().Kinds;
            var count = kinds.Length;
            var defs = alloc<BroadcastDef>(count);
            for(var j=0; j<kinds.Length; j++)
                seek(defs,j) = def(skip(kinds,j));
            return defs;
        }
    }
}