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
    using static ReflectionFlags;

    [ApiHost]
    public readonly struct ClrFields
    {
        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        public static ReadOnlySpan<FieldValue> values<T>(in T src)
            where T : struct
        {
            var fields = span(typeof(T).DeclaredFields());
            var dst = alloc<FieldValue>(fields.Length);
            values(src, fields, dst);
            return dst;
        }

        [Op, Closures(Closure)]
        public static void values<T>(in T src, Span<FieldValue> dst)
            where T : struct
        {
            var fields = span(typeof(T).DeclaredFields());
            values(src, fields, dst);
        }

        public static FieldValue<S>[] values<S,T>(S src)
            where S : struct
        {
            var fields = @readonly(typeof(S).DeclaredInstanceFields());
            var buffer = alloc<FieldValue<S>>(fields.Length);
            var dst = span(buffer);
            ref var target = ref first(dst);
            var tRef = __makeref(src);
            var count = fields.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                seek(target,i) = new FieldValue<S>(f, f.GetValueDirect(tRef));
            }
            return buffer;
        }

        [Op, Closures(Closure)]
        public static void values<T>(in T src, ReadOnlySpan<ClrFieldAdapter> fields, Span<FieldValue> dst)
            where T : struct
        {
            ref var target = ref first(dst);
            var tRef = __makeref(edit(src));
            var count = fields.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                seek(target,i) = new FieldValue(f, f.GetValueDirect(tRef));
            }
        }

        [Op, Closures(Closure)]
        public static void values<T>(in T src, ReadOnlySpan<FieldInfo> fields, Span<FieldValue> dst)
            where T : struct
        {
            ref var target = ref first(dst);
            var tRef = __makeref(edit(src));
            var count = fields.Length;
            for(var i=0u; i<count; i++)
            {
                ref readonly var f = ref skip(fields,i);
                seek(target,i) = new FieldValue(f, f.GetValueDirect(tRef));
            }
        }

        [Op, Closures(Closure)]
        public static FieldValues<T> values<T>(in T src, FieldInfo[] fields)
            where T : struct
        {
            var tr = __makeref(edit(src));
            var count = fields.Length;
            var fv = @readonly(fields);

            var buffer = sys.alloc<FieldValue<T>>(count);
            var dst = span(buffer);
            for(ushort i=0; i<count; i++)
            {
                ref readonly var field = ref skip(fv,i);
                seek(dst,i) = new FieldValue<T>(field,  field.GetValueDirect(tr));
            }

            return new FieldValues<T>(buffer);
        }

        /// <summary>
        /// Returns a <see cref='ClrFieldAdapter'/> readonly span of the declared instance fields defined by the source
        /// </summary>
        /// <param name="src">The source type</param>
        [MethodImpl(Inline), Op]
        public static ReadOnlySpan<ClrFieldAdapter> instance(Type src, bool declared = true)
            => Clr.adapt(src.GetFields(declared ? BF_DeclaredInstance : BF_All));

        [Op]
        public unsafe static FieldRef primal(MemoryAddress @base, MemoryAddress offset, FieldInfo src)
        {
            var data = sys.constant(src);
            var type = src.FieldType;
            var datatype = PrimalBits.kind(type);
            if(data is string s)
            {
                var content = span(s);
                var size = s.Length*2;
                var seg = MemorySegs.define(pvoid(first(content)), size);
                return new FieldRef(src, seg);
            }
            else if(type.IsEnum)
            {
                var nk = type.GetEnumUnderlyingType().NumericKind();
                var size = nk.Width()/8;
                var seg = MemorySegs.define(@base + offset, size);
                return new FieldRef(src, seg);
            }
            else if(type.IsPrimalNumeric())
            {
                var nk = type.NumericKind();
                var size = nk.Width()/8;
                var seg = MemorySegs.define(@base + offset, size);
                return new FieldRef(src, seg);
            }
            else if(type.IsChar())
                return new FieldRef(src, MemorySegs.define(@base + offset, 2));
            else if(type.IsDecimal())
                return new FieldRef(src, MemorySegs.define(@base + offset, 16));
            return FieldRef.Empty;
        }

        [Op]
        public static FieldRef[] literals(ReadOnlySpan<Type> src)
        {
            var dst = list<FieldRef>();
            var count = src.Length;
            for(var i=0u; i<count; i++)
            {
                var type = skip(src,i);
                var fields = ClrLiterals.search(type);
                var @base = address(type);
                var offset = MemoryAddress.Zero;
                for(var j=0u; j<fields.Length; j++)
                {
                    var fi = fields[j];
                    var segment = primal(@base, offset, fi);
                    if(segment.IsNonEmpty)
                    {
                        dst.Add(segment);
                        offset += segment.DataSize;
                    }
                }
            }
            return dst.Array();
        }
    }
}