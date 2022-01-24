//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigModels
    {
        public readonly struct Rel8 : IAsmSigOp<Rel8,RelToken>
        {
            public RelToken Token
                => RelToken.rel8;

            public AsmSigOpKind OpKind
                => AsmSigOpKind.Rel;

            public NativeSize Size
                => NativeSizeCode.W8;
        }
    }
}