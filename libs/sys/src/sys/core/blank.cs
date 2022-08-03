//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct sys
    {
        /// <summary>
        /// Tests whether the source string is null or empty
        /// </summary>
        /// <param name="src">The string to evaluate</param>
        [MethodImpl(Options), Op]
        public static bool blank(string src)
            => string.IsNullOrWhiteSpace(src);
    }
}