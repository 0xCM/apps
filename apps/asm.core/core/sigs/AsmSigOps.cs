//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct AsmSigOps
    {
        public AsmSigOp Op0;

        public AsmSigOp Op1;

        public AsmSigOp Op2;

        public AsmSigOp Op3;

        public AsmSigOp Op4;

        public AsmSigOp this[int i]
        {
            get => i switch {
                0 => Op0,
                1 => Op1,
                2 => Op2,
                3 => Op3,
                4 => Op4,
                _ => AsmSigOp.Empty,
            };
        }

        public byte OpCount
        {
            [MethodImpl(Inline)]
            get => (byte)(u8(Op0.IsNonEmpty) + u8(Op1.IsNonEmpty) + u8(Op2.IsNonEmpty) + u8(Op3.IsNonEmpty) + u8(Op4.IsNonEmpty));
        }

        public static AsmSigOps Empty => default;
    }
}