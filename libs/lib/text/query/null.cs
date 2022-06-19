//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using C = AsciCode;

    partial struct SymbolicQuery
    {
        /// <summary>
        /// Returns true if the source represents the null terminator
        /// </summary>
        /// <param name="src">The character to evaluate</param>
        [MethodImpl(Inline), Op]
        public static bit @null(C src)
            => src == C.Null;

        /// <summary>
        /// Returns true if the source is the null terminator
        /// </summary>
        /// <param name="src">The character to evaluate</param>
        [MethodImpl(Inline), Op]
        public static bit @null(char src)
            => src == (char)C.Null;
    }
}