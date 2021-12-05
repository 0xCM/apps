//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    partial struct ClrLiterals
    {
        [MethodImpl(Inline), Op]
        public static FieldInfo[] literals(FieldInfo[] src)
            => src.Where(x => x.IsLiteral);
    }
}