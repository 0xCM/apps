//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using Operands;

    using static Root;
    using static AsmPrefixCodes;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static VexPrefix vex(VexPrefixKind kind)
            => new VexPrefix(kind);

        [MethodImpl(Inline), Op]
        public static VexPrefix vex(VexPrefixKind kind, byte b1)
            => new VexPrefix(kind, b1);

        [MethodImpl(Inline), Op]
        public static VexPrefix vex(VexPrefixKind kind, byte b1, byte b2)
            => new VexPrefix(kind, b1, b2);
    }
}