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

    partial struct gcalc
    {
        /// <summary>
        /// Slices an interval into manageable pieces, disjoint even
        /// </summary>
        /// <param name="src">The source interval</param>
        /// <param name="width">The partition width</param>
        /// <param name="precision">The precision with which the calculations are carried out</param>
        /// <typeparam name="T">The primal numeric type over which the interval is defined</typeparam>
        [Op, Closures(AllNumeric)]
        public static Index<T> partition<T>(Interval<T> src, T width, int? precision = null)
            where T : unmanaged
        {
            var dst = list<T>();
            var scale = precision ?? 4;
            if(src.LeftClosed)
                dst.Add(src.Left);

            var next = gfp.round(gmath.add(src.Left, width), scale);
            while(gmath.lt(next,src.Right))
            {
                dst.Add(next);
                next = gfp.round(gmath.add(next, width), scale);
            }

            if(src.RightClosed)
                dst.Add(src.Right);

            return dst.ToArray();
        }
    }
}