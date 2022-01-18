//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    partial class XTend
    {
        public static Dictionary<string,FieldValue> FieldValues(this ICmd src)
            => ClrFields.values(src);

        public static Dictionary<string,FieldValue> FieldValues(this ICmd src, FieldInfo[] fields)
            => ClrFields.values(src, fields);
    }
}