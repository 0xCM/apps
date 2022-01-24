//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigModels
    {
        public readonly struct Rel32 : IAsmSigOp<Rel32,RelToken>
        {
            public RelToken Token
                => RelToken.rel32;

            public AsmSigOpKind OpKind
                => AsmSigOpKind.Rel;

            public NativeSize Size
                => NativeSizeCode.W32;
        }
    }
}