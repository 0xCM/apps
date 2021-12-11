//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Globalization;

    using static core;

    partial struct Hex
    {
        /// <summary>
        /// Parses a space-delimited sequence of hex text
        /// </summary>
        /// <param name="src">The space-delimited hex</param>
        [Op]
        public static Outcome hexdata(string src, out byte[] dst)
            => HexParser.hexdata(src, out dst);

        /// <summary>
        /// Parses a sequence of hex bytes, delimited by a space or comma
        /// </summary>
        /// <param name="src">The source</param>
        /// <param name="dst">The target</param>
        [Op]
        public static Outcome hexbytes(string src, out BinaryCode dst)
            => HexParser.hexbytes(src, out dst);

        [Op]
        public static Outcome<uint> hexbytes(string src, Span<byte> dst)
            => HexParser.hexbytes(src, dst);
    }
}