//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Clr
    {
        [MethodImpl(Inline), Op]
        public static ClrPrimitiveInfo describe(PrimalKind src)
            => new ClrPrimitiveInfo(src, width(src), sign(src), (PrimalCode)typecode(src));
    }
}