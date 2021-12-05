//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct Asci
    {
        /// <summary>
        /// Encodes a 2-character asci sequence
        /// </summary>
        /// <param name="a">The first asci code</param>
        /// <param name="b">The second asci code</param>
        [MethodImpl(Inline), Op]
        public static asci2 define(AsciCode a, AsciCode b)
            => new asci2(AsciSymbols.pack(a,b));

        /// <summary>
        /// Encodes a 3-character asci sequence
        /// </summary>
        /// <param name="a">The first asci code</param>
        /// <param name="b">The second asci code</param>
        /// <param name="c">The third asci code</param>
        [MethodImpl(Inline), Op]
        public static asci4 define(AsciCode a, AsciCode b, AsciCode c)
            => new asci4(AsciSymbols.pack(a, b, c, out var _ ));

        /// <summary>
        /// Encodes a 4-character asci sequence
        /// </summary>
        /// <param name="a">The first asci code</param>
        /// <param name="b">The second asci code</param>
        /// <param name="c">The third asci code</param>
        /// <param name="d">The fourth asci code</param>
        [MethodImpl(Inline), Op]
        public static asci4 define(AsciCode c0, AsciCode c1, AsciCode c2, AsciCode c3)
            => new asci4(AsciSymbols.pack(c0,c1,c2,c3, out var dst));
    }
}