//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class ClrQuery
    {
        /// <summary>
        /// If source type is n nullable value type, returns the underlying type; otherwise returns the empty type
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static Type TNullableBase(this Type src)
            => src.IsNullableType() ? Nullable.GetUnderlyingType(src) : typeof(void);
    }
}