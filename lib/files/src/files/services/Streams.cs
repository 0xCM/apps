//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.IO;
    using System.Text;

    using static Root;

    [ApiHost]
    public readonly struct Streams
    {
        /// Allocates a caller-disposed reader for the source
        /// </summary>
        /// <param name="src">The source stream</param>
        [Op]
        public static StreamReader reader(Stream src)
            => new StreamReader(src);

        /// <summary>
        /// Allocates a caller-disposed stream over a string
        /// </summary>
        /// <param name="src">The source text</param>
        /// <param name="encoding">The text encoding</param>
        [Op]
        public static MemoryStream memory(string src, Encoding encoding = null)
            => new MemoryStream((encoding ?? Encoding.UTF8).GetBytes(src ?? EmptyString));
    }
}