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

    partial class ClrQuery
    {
        /// <summary>
        /// Determines whether the property has a public setter
        /// </summary>
        /// <param name="p">The property to examine</param>
        [MethodImpl(Inline), Op]
        public static bool HasPublicSetter(this PropertyInfo p)
            => p.GetSetMethod() != null;
    }
}