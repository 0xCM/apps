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

    partial class Cells
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T bits<T>(ref Cell128<T> src, int max, int min)
            where T : unmanaged
        {
            ref var cells = ref @as<Cell128<T>,T>(src);
            var width = max - min + 1;
            var offset = min/8;
            var length = width/8;
            ref var start = ref seek(cells, offset);
            ref var cell = ref core.first(cover(start, length));
            return ref cell;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T bits<T>(ref Cell256<T> src, int max, int min)
            where T : unmanaged
        {
            ref var cells = ref @as<Cell256<T>,T>(src);
            var width = max - min + 1;
            var offset = min/8;
            var length = width/8;
            ref var start = ref seek(cells, offset);
            ref var cell = ref core.first(cover(start, length));
            return ref cell;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ref T bits<T>(ref Cell512<T> src, int max, int min)
            where T : unmanaged
        {
            ref var cells = ref @as<Cell512<T>,T>(src);
            var width = max - min + 1;
            var offset = min/8;
            var length = width/8;
            ref var start = ref seek(cells, offset);
            ref var cell = ref core.first(cover(start, length));
            return ref cell;
        }
    }
}