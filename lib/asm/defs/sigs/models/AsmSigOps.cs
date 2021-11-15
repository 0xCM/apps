//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmSigOps
    {
        public byte OpCount;

        public AsmSigOp Op1;

        public AsmSigOp Op2;

        public AsmSigOp Op3;

        public AsmSigOp Op4;
    }
}