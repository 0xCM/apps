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
            TableEmit(SigOpRules.DecomposeSigs(opcodes).View, AsmSigOpCode.RenderWidths, ProjectDb.TablePath<AsmSigOpCode>("sdm", "decomposed"));
        }
    }
}