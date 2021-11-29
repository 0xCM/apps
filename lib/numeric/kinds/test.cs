//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

     using static Root;

    partial class NumericKinds
    {
        /// <summary>
        /// Returns true if a type is a numeric type, false otherwise
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static bool test(Type src)
            => kind(src) != 0;
    }
}