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

    public readonly struct Faceted
    {
        public static Outcome parse(string src, out Facet dst)
        {
            var i = text.index(src,Chars.Colon);
            if(i > 0)
            {
                var key = text.trim(text.left(src,i));
                var value = text.trim(text.right(src,i));
                dst = new Facet(key,value);
                return true;
            }
            dst = Facet.Empty;
            return false;
        }

        public static Index<Facet> facets<T>(T src)
            where T : struct
        {
            var props = @readonly(typeof(T).DeclaredInstanceProperties());
            var fields = @readonly(typeof(T).DeclaredInstanceFields());

            var _ref = __makeref(src);
            var propcount = props.Length;
            var fieldcount = fields.Length;
            var count = propcount + fieldcount;
            var buffer = alloc<Facet>(count);
            ref var dst = ref first(buffer);
            var j=0u;
            for(var i=0; i<propcount; i++)
            {
                ref readonly var prop = ref skip(props,i);
                seek(dst,j++) = new Facet(prop.Name, prop.GetValue(src));
            }
            for(var i=0; i<fieldcount; i++)
            {
                ref readonly var field = ref skip(fields,i);
                seek(dst,j++) = new Facet(field.Name, field.GetValue(src));
            }

            return buffer;
        }

        public static Outcome parse(ReadOnlySpan<string> src, out Facets dst)
        {
            dst = Facets.Empty;
            var result = Outcome.Success;
            var count = src.Length;
            var buffer = alloc<Facet>(count);
            for(var i=0; i<count; i++)
            {
                result = parse(skip(src,i), out seek(buffer,i));
                if(result.Fail)
                    break;
            }
            return result;
        }

        internal static string format<K,V>(Facet<K,V> src)
            => RP.facet(src.Key, src.Value);

        internal static string format<T>(Facet<T> src)
            => RP.facet(src.Key, src.Value);

        internal static string format(Facet src)
            => RP.facet(src.Key, src.Value);

        internal static string format(Facets src)
        {
            var dst = text.buffer();
            var count = src.Count;
            for(var i=0; i<count; i++)
                dst.AppendLine(src[i].Format());
            return dst.Emit();
        }
    }
}