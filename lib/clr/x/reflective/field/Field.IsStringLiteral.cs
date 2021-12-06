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

    partial class ClrQuery
    {
        [MethodImpl(Inline), Op]
        public static bool IsStringLiteral(this FieldInfo src)
            => src.IsLiteral && src.FieldType == typeof(string);
    }
}