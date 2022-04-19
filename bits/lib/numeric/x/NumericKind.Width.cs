//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static NumericKinds;

    partial class XNKind
    {
        /// <summary>
        /// Determines whether a numeric kind designates a signed integral type
        /// </summary>
        /// <param name="src">The source kind</typeparam>
        [MethodImpl(Inline), Op]
        public static bool IsSigned(this NumericKind src)
            => signed(src);

        /// <summary>
        /// Determines the width of a numeric kind
        /// </summary>
        /// <param name="kind">The source kind</param>
        [MethodImpl(Inline), Op]
        public static NativeTypeWidth TypeWidth(this NumericKind kind)
            => width(kind);

        /// <summary>
        /// Determines the width of the represented kind in bits
        /// </summary>
        /// <param name="k">The kind to examine</param>
        [MethodImpl(Inline), Op]
        public static int Width(this NumericKind k)
            => (int)(ushort)k;
    }
}