//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    using static Root;
    using static ReflectionFlags;

    partial class ClrQuery
    {
        [MethodImpl(Inline), Op]
        public static FieldInfo[] SequentialFields(this Type src)
            => src.GetFields(BF_DeclaredInstance).OrderBy(f => f.MetadataToken);
    }
}