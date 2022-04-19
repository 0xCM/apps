//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Reflection;

    partial class XApi
    {
        /// <summary>
        /// Queries the stream for mathods that are of a specified kind
        /// </summary>
        /// <param name="src">The source methods</param>
        /// <param name="kind">The kind to match</param>
        [Op]
        public static MethodInfo[] OfKind(this MethodInfo[] src, ApiClassKind kind)
            => from m in src where m.ApiClass() == kind select m;
    }
}