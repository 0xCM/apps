//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class XNKind
    {
        /// <summary>
        /// Converts a numeric indicator to a character
        /// </summary>
        /// <param name="src">The source kind</param>
        [MethodImpl(Inline), Op]
        public static char ToChar(this NumericIndicator src)
            => NumericKinds.@char(src);
    }
}