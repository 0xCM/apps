//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XTend
    {
        [MethodImpl(Inline), Op]
        public static bool IsSigned(this ClrEnumKind src)
            => ((ClrPrimitiveKind)src).IsSigned();
    }
}