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

    partial struct LookupTables
    {
        /// <summary>
        /// Defines a key for a cell with coordinates (<paramref name='row'/>, <paramref name='col'/>)
        /// </summary>
        /// <param name="row">The row index</param>
        /// <param name="col">The column index</param>
        [MethodImpl(Inline), Op]
        public static LookupKey key(ushort row, ushort col)
            => @as<uint,LookupKey>((uint)row | ((uint)col) << 16);

        [MethodImpl(Inline), Op]
        public static ref readonly LookupKey key(LookupKeys src, ushort row, ushort col)
        {
            var data = src.View;
            var i = offset(src.Dim, row, col);
            return ref skip(data,i);
        }
    }
}