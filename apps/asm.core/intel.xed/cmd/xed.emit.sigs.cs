//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class AsmCoreCmd
    {
        [CmdOp("xed/emit/sigs")]
        void EmitInstSig()
        {
            Xed.Rules.EmitInstSigs(Xed.Views.Patterns);
        }
    }
}