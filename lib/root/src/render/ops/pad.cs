//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct RP
    {
        /// <summary>
        /// Defines the format pattern '{0,pad}'
        /// </summary>
        /// <param name="pad">The pad width specifier</param>
        [MethodImpl(Inline), Op]
        public static string pad(int pad)
            => "{0," + pad.ToString() + "}";

        /// <summary>
        /// Defines the format pattern '{n,pad}'
        /// </summary>
        /// <param name="n">The zero-based slot index</param>
        /// <param name="pad">The pad width specifier</param>
        [MethodImpl(Inline), Op]
        public static string pad(uint n, int pad)
            => "{" + n.ToString() + "," + pad.ToString() + "}";
    }
}
