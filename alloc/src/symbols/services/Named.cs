//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public readonly struct Named
    {
        const NumericKind Closure = UnsignedInts;

        [Op, Closures(Closure)]
        public static Index<NamedValue> values<T>(T src)
        {
            var props = @readonly(typeof(T).DeclaredInstanceProperties());
            var fields = @readonly(typeof(T).DeclaredInstanceFields());
            var propcount = props.Length;
            var fieldcount = fields.Length;
            var count = propcount + fieldcount;
            var buffer = alloc<NamedValue>(count);
            ref var dst = ref first(buffer);
            var j=0u;
            for(var i=0; i<propcount; i++)
            {
                ref readonly var prop = ref skip(props,i);
                seek(dst,j++) = new NamedValue(prop.Name, prop.GetValue(src));
            }
            for(var i=0; i<fieldcount; i++)
            {
                ref readonly var field = ref skip(fields,i);
                seek(dst,j++) = new NamedValue(field.Name, field.GetValue(src));
            }

            return buffer;
        }

        [MethodImpl(Inline), Op]
        public static NameList list(Name name, Name[] names)
            => (name,names);

        [MethodImpl(Inline), Op]
        public static Name kind(string name)
            => name;

        [MethodImpl(Inline), Op]
        public static NameList list(string name, string[] names)
            => (name, names.Select(x => (Name)x));

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NamedValue<V> value<V>(string name, V value)
            => new NamedValue<V>(name,value);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static NamedValues<V> values<V>(NamedValue<V>[] src)
            => new NamedValues<V>(src);

        [MethodImpl(Inline)]
        public static NamedValue<K,V> value<K,V>(K name, V value)
            => new NamedValue<K,V>(name,value);
    }
}