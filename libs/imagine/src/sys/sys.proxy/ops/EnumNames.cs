//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq;

    using static ApiOpaqueClass;

    partial struct proxy
    {
        [MethodImpl(Options), Opaque(GetEnumNames)]
        public static string[] EnumNames(Type src)
            => Enum.GetNames(src);
    }
}