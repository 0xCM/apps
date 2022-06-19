//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using C = AsciCode;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Determines whether the lower 8 bits of a <see cref='char'/> is in [0..9 | a..f | A..F]
        /// </summary>
        /// <param name="src">The value to test</param>
        [MethodImpl(Inline), Op]
        public static bit hexdigit(char src)
            => Digital.test(base16, src);

        /// <summary>
        /// Determines whether a <see cref='C'/> represents a character in [0..9 | a..f | A..F]
        /// </summary>
        /// <param name="src"></param>
        [MethodImpl(Inline), Op]
        public static bit hexdigit(C src)
            => Digital.test(base16, src);
    }
}