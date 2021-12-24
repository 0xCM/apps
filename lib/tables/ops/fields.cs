//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    partial struct Tables
    {
        /// <summary>
        /// Discerns a <see cref='ClrRecordFields'/> for a parametrically-identified record type
        /// </summary>
        /// <typeparam name="T">The record type</typeparam>
        [Op, Closures(Closure)]
        public static ClrTableField[] fields<T>()
            where T : struct
                => fields(typeof(T));

        /// <summary>
        /// Discerns a <see cref='ClrRecordFields'/> for a specified record type
        /// </summary>
        /// <param name="src">The record type</typeparam>
        [Op]
        public static ClrTableField[] fields(Type src)
        {
            var fields = src.DeclaredPublicInstanceFields().ToReadOnlySpan();
            var count = fields.Length;
            var buffer = sys.alloc<ClrTableField>(count);
            ref var dst = ref first(buffer);
            for(var i=z16; i<count; i++)
                seek(dst, i) = new ClrTableField(i, skip(fields,i));
            return buffer;
        }
    }
}