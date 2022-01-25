//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmSpec
    {
        public AsmMnemonic Mnemonic;

        public AsmOpCode OpCode;

        public AsmOperands Operands;

        public static AsmSpec Empty => default;

        public string Format()
            => AsmSpecs.format(this);

        public override string ToString()
            => Format();
    }
}