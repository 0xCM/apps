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
    public readonly struct AsmOcToken
    {
        public AsmOcTokenKind Kind {get;}

        public byte Value {get;}

        [MethodImpl(Inline)]
        public AsmOcToken(AsmOcTokenKind kind, byte value)
        {
            Kind = kind;
            Value = value;
        }
    }
}