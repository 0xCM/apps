//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct core
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Index<T> resequence<T>(Index<T> src)
            where T : ISequential<T>
        {
            for(var i=0u; i<src.Length; i++)
                src[i].Seq = i;
            return src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static T[] resequence<T>(T[] src)
            where T : ISequential<T>
        {
            for(var i=0u; i<src.Length; i++)
                seek(src,i).Seq = i;
            return src;
        }

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Span<T> resequence<T>(Span<T> src)
            where T : ISequential<T>
        {
            for(var i=0u; i<src.Length; i++)
                seek(src,i).Seq = i;
            return src;
        }
    }

    partial class XTend
    {
        public static T[] Resequence<T>(this T[] src)
            where T : ISequential<T>
                => core.resequence(src);

        public static Index<T> Resequence<T>(this Index<T> src)
            where T : ISequential<T>
                => core.resequence(src);

        public static Span<T> Resequence<T>(this Span<T> src)
            where T : ISequential<T>
                => core.resequence(src);
    }
}