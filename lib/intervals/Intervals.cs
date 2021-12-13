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

    [ApiHost]
    public readonly partial struct Intervals
    {
        const NumericKind Closure = UnsignedInts;

        [Op]
        public static bool parse(string src, ClosedInterval<int> bounds, out int dst, out Outcome outcome)
        {
            outcome = NumericParser.parse(src, out dst);
            if(!outcome)
                return false;

            if(!contains(bounds,dst))
            {
                outcome = (false, $"The parsed value {dst} is not with the required range {bounds}");
                return false;
            }
            return true;
        }

        [MethodImpl(Inline)]
        static ulong left<T>(in ClosedInterval<T> src)
            where T : unmanaged
                => uint64(src.Min);

        [MethodImpl(Inline)]
        static ulong right<T>(in ClosedInterval<T> src)
            where T : unmanaged
                => uint64(src.Max);

        public static string format<T>(ClosedIntervals<T> src)
            where T : unmanaged
        {
            var dst = text.buffer();
            dst.Append("<<");
            for(var i=0u; i<src.SegCount; i++)
                dst.Append(src.Range(i).Format());
            dst.Append(">>");
            return dst.Emit();
        }
    }
}