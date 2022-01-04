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
    using static core;

    [StructLayout(LayoutKind.Sequential)]
    public readonly struct AsmCode : IComparable<AsmCode>
    {
        public SourceText Asm {get;}

        public AsmHexCode Code {get;}

        [MethodImpl(Inline)]
        public AsmCode(SourceText asm, AsmHexCode code)
        {
            Asm = asm;
            Code = code;
        }

        public int CompareTo(AsmCode src)
            => Asm.CompareTo(src.Asm);
    }
}