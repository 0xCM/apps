//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        void EmitSigDecomps(Index<SdmOpCodeDetail> details)
            => TableEmit(SigOpRules.DecomposeSigs(details.Select(x => SdmOps.form(x))).View, SdmSigOpCode.RenderWidths, SdmPaths.SigDecompTable());
    }
}