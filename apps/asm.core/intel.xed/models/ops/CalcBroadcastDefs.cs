//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelXed
    {
        void EmitBroadcastDefs()
            => TableEmit(BcastDefs().View, BroadcastDef.RenderWidths, AppDb.XedTable<BroadcastDef>());

        [MethodImpl(Inline), Op]
        public static Index<BroadcastDef> BcastDefs()
            => _BroadcastDefs;
    }
}