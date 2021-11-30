//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static NumericKinds;

    partial class XNKind
    {
        [MethodImpl(Inline), Op]
        public static TypeCode ToTypeCode(this NumericKind src)
            => Type.GetTypeCode(type(src));
    }
}