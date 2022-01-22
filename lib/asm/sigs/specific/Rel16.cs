//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmSigModels
    {
        public readonly struct Rel16 : IAsmSigOp<Rel16,RelToken>
        {
            public RelToken Token
                => RelToken.rel16;

            public AsmSigOpKind Kind
                => AsmSigOpKind.Rel;

            public NativeSize Size
                => NativeSizeCode.W16;

        }
    }
}