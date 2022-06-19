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
        /// Deterines the source assembly <see cref='Module'/> definitions
        /// </summary>
        /// <param name="src">The assembly to query</param>
        [Op]
        public static Module[] Modules(this Assembly src)
            => src.Modules.Array();
    }
}