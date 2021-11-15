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
        /// Allocates and defines a <see cref='LookupKeys'/> sequence that covers a table of dimension <paramref name='rows'/>x<paramref name='cols'/>
        /// </summary>
        /// <param name="rows">The row count</param>
        /// <param name="cols">The column count</param>
        [Op]
        public static LookupKeys keys(ushort rows, ushort cols)
        {
            var dst = alloc<LookupKey>(rows*cols);
            keys(rows,cols,dst);
            return new LookupKeys((rows,cols),dst);
        }

        [MethodImpl(Inline), Op]
        public static void keys(ushort rows, ushort cols, Span<LookupKey> dst)
        {
            var dim = new GridDim<ushort>(rows,cols);
            for(var i=0; i<rows; i++)
            for(var j=0; j<cols; j++)
                seek(dst, offset(dim,(ushort)i,(ushort)j)) = key((ushort)i, (ushort)j);
        }
    }
}