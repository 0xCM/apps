//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public struct SdmSigDetail
    {
        public AsmSigExpr Sig;

        public AsmOpCode OpCode;

        [MethodImpl(Inline)]
        public SdmSigDetail(AsmSigExpr sig, AsmOpCode oc)
        {
            Sig = sig;
            OpCode = oc;
        }
    }
}