//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Diagnostics;
    using System.Linq;

    partial class ClrQuery
    {
        [Op]
        public static Type[] Classes(this Assembly a)
            => a.Types().Classes();

        [Op]
        public static Type[] Classes(this Assembly a, string name)
            => a.Classes().Where(c => c.Name == name);

        [Op]
        public static string[] DebugFlags(this Assembly src)
            => src.GetCustomAttributes<DebuggableAttribute>().Select(a => a.DebuggingFlags.ToString()).Array();
    }
}