//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;
    using static core;

    partial struct ClrLiterals
    {
        /// <summary>
        /// Selects the binary literals declared by a specified type that are of a specified primal type
        /// </summary>
        /// <param name="src">The source type</param>
        /// <typeparam name="T">The primal literal type</typeparam>
        [MethodImpl(Inline), Op, Closures(Integers8x64k)]
        public static T[] values<T>(Base2 @base, Type src)
            where T : unmanaged
                => src.LiteralFields().Where(f => f.FieldType == typeof(T) && f.Tagged<BinaryLiteralAttribute>()).Select(x => (T)x.GetRawConstantValue());

        [MethodImpl(Inline), Op]
        public static void values(in CoveredLiterals src, Span<object> dst)
            => src.WriteValues(dst);

        [MethodImpl(Inline)]
        public static void values<T>(ref T src, Span<Paired<FieldInfo,object>> dst)
            where T : struct
        {
            var fields = span(typeof(T).DeclaredFields());
            values(ref src, fields, dst);
        }

        [MethodImpl(Inline)]
        public static void values<T>(ref T src, ReadOnlySpan<FieldInfo> fields, Span<Paired<FieldInfo,object>> dst)
            where T : struct
        {
            ref var target = ref first(dst);
            var tRef = __makeref(src);
            var count = fields.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                seek(target,i) = (f,f.GetValueDirect(tRef));
            }
        }

        [Op, Closures(Closure)]
        public static Paired<FieldInfo,T>[] values<T>(Type src)
        {
            var fields = @readonly(search<T>(src));
            var buffer = alloc<Paired<FieldInfo,T>>(fields.Length);
            var dst = span(buffer);
            ref var target = ref first(dst);
            var tRef = __makeref(src);
            var count = fields.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                seek(target,i) = (f,(T)f.GetValueDirect(tRef));
            }
            return buffer;
        }
    }
}