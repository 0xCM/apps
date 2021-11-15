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

        public CharBlock16 Mnemonic;

        public CharBlock64 Operands;

        public CharBlock48 Expr;
    }
}