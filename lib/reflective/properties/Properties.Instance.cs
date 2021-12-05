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
        /// <summary>
        /// Selects the instance properties from an array
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static PropertyInfo[] Instance(this PropertyInfo[] src)
            => src.Where(p => !p.IsStatic());
    }
}