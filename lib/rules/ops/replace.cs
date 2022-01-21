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

    partial struct Rules
    {
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static ReplaceRule<T> replace<T>(T src, T dst)
            where T : IEquatable<T>
                => new ReplaceRule<T>(src,dst);

        [Op, Closures(Closure)]
        public static Replacements<T> replacements<T>(params Pair<T>[] src)
            where T : IEquatable<T>
        {
            var count = src.Length;
            var buffer = sys.alloc<ReplaceRule<T>>(count);
            for(var i=0; i<count; i++)
                seek(buffer,i) = new ReplaceRule<T>(skip(src,i).Left, skip(src,i).Right);
            return buffer;
        }
    }
}