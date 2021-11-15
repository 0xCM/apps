//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;
    using System.Linq;

    partial class ClrQuery
    {
        /// <summary>
        /// Selects all fields from the source types
        /// </summary>
        /// <param name="src">The types to search</param>
        [Op]
        public static FieldInfo[] Fields(this Type[] src)
            => src.SelectMany(x => x.Fields()).ToArray();
    }
}