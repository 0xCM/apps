//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmSigs;


    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static Rel8 rel8()
            => default;

        [MethodImpl(Inline), Op]
        public static Rel16 rel16()
            => default;

        [MethodImpl(Inline), Op]
        public static Rel32 rel32()
            => default;

        [MethodImpl(Inline), Op]
        public static Rel8 rel(W8 w)
            => default;

        [MethodImpl(Inline), Op]
        public static Rel16 rel(W16 w)
            => default;

        [MethodImpl(Inline), Op]
        public static Rel32 rel(W32 w)
            => default;
    }
}