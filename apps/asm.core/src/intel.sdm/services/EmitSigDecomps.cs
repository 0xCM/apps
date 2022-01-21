//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class IntelSdm
    {
        void EmitSigDecomps(Index<SdmOpCodeDetail> details)
        {
            var opcodes = details.Select(x => SdmOps.sigoc(x));
            var records = SigOpRules.DecomposeSigs(opcodes);
            TableEmit(records.View, SdmOpCodeSig.RenderWidths, ProjectDb.TablePath<SdmOpCodeSig>("sdm", "decomposed"));
       }
    }
}