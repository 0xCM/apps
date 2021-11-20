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

    [StructLayout(LayoutKind.Sequential, Size=2)]
    public readonly struct AsmSigToken
    {
        public byte Value {get;}

        public AsmSigTokenKind Kind {get;}

        [MethodImpl(Inline)]
        public AsmSigToken(byte value, AsmSigTokenKind kind)
        {
            Value = value;
            Kind = kind;
        }
    }
}