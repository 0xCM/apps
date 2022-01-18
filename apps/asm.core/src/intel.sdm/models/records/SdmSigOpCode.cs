//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct SdmSigOpCode
    {
        public uint OpCodeKey;

        public AsmSigExpr Sig;

        public AsmOpCode OpCode;

        public string Format()
            => string.Format("{0} {1}", Sig, OpCode);


        public override string ToString()
            => Format();
    }
}