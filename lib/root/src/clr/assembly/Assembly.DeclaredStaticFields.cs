//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class ClrQuery
    {
        [Op]
        public static FieldInfo[] DeclaredStaticFields(this Assembly src)
            => src.Types().DeclaredStaticFields();
    }
}