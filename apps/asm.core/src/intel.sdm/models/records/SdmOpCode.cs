//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public struct SdmOpCode
    {
        public uint OpCodeKey;

        public AsmMnemonic Mnemonic;

        public CharBlock64 Operands;

        public AsmOpCode Expr;
    }
}