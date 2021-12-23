//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;
    using static SdmModels;

    partial class IntelSdm
    {
        /// <summary>
        /// Tests whether the specified input sequence is of the form ' .' or '. '
        /// </summary>
        /// <param name="c0">The first character in the placeholder sequence</param>
        /// <param name="c1">The second character in the placeholder sequence</param>
        [MethodImpl(Inline), Op]
        public static bool placeholder(char c0, char c1)
            => (c0 == Placeholder.Space && c1 == Placeholder.Dot)
            || (c0 == Placeholder.Dot && c1 == Placeholder.Space);

        /// <summary>
        /// Finds the beginning of the toc entry placeholders
        /// </summary>
        /// <param name="src">The data source</param>
        public static int placeholder(string src)
        {
            var i = text.index(src," . . . .");
            var j = text.index(src,". . . . ");
            if(i != NotFound && j != NotFound)
                return min(i,j);
            else
                return NotFound;
        }
    }
}