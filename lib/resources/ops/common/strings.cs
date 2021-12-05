//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;

    partial struct Resources
    {
        [Op]
        public static Index<StringRes> strings(Type src)
        {
            var values = span(ClrLiterals.values<string>(src));
            var count = values.Length;
            var buffer = alloc<StringRes>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(values,i);
                seek(dst,i) = new(fv.Left,fv.Right);
            }
            return buffer;
        }

        [Op, Closures(Closure)]
        public static Index<StringRes<T>> strings<T>(Type src)
            where T : unmanaged
        {
            var values = span(ClrLiterals.values<string>(src));
            var count = values.Length;
            var buffer = alloc<StringRes<T>>(count);
            var dst = span(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var fv = ref skip(values,i);
                seek(dst,i) = define(@as<uint,T>(i), fv.Right, (uint)fv.Right.Length*2);
            }
            return buffer;
        }
    }
}