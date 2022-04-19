//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class BitMatrix
    {
        /// <summary>
        /// Loads a generic bitmatrix from a rowbit sequence
        /// </summary>
        /// <param name="rows">The row content</param>
        /// <typeparam name="T">The primal type over which the matrix is constructed</typeparam>
        [MethodImpl(Inline)]
        public static BitMatrix<T> from<T>(in RowBits<T> src)
            where T : unmanaged
        {
            if(src.RowCount != width<T>())
                Errors.Throw($"{width<T>()} != {src.RowCount}");

            return load(src.Storage);
        }

        [MethodImpl(Inline), Op]
        public static BitMatrix32 from(N32 n, Span<byte> src)
            => new BitMatrix32(src.AsUInt32());
    }
}