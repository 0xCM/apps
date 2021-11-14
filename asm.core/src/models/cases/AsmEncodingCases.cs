//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmEncodingCases
    {
        public Index<AsmEncodingCase> Cases {get;}

        [MethodImpl(Inline)]
        public AsmEncodingCases(Index<AsmEncodingCase> src)
        {
            Cases = src;
        }

        public ref AsmEncodingCase this[ushort index]
        {
            [MethodImpl(Inline)]
            get => ref Cases[index];
        }

        public ReadOnlySpan<AsmEncodingCase> View
        {
            [MethodImpl(Inline)]
            get => Cases.View;
        }
    }
}