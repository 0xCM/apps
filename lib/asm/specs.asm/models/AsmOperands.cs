//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmOperands
    {
        public byte OpCount;

        public AsmOperand Op0;

        public AsmOperand Op1;

        public AsmOperand Op2;

        public AsmOperand Op3;

        public static AsmOperands Empty => default;
    }
}