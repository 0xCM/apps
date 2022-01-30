//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public struct SdmSigDetail
    {
        public uint Key;

        public AsmSigExpr Sig;

        public AsmOcExpr OpCode;

        [MethodImpl(Inline)]
        public SdmSigDetail(uint key, AsmSigExpr sig, AsmOcExpr oc)
        {
            Key = key;
            Sig = sig;
            OpCode = oc;
        }
    }
}