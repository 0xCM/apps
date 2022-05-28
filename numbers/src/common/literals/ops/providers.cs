//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Literals
    {
        public static Index<LiteralProvider> providers(Assembly src)
            => providers(src.TaggedTypes<LiteralProviderAttribute>());

        public static Index<LiteralProvider> providers(Assembly[] src)
            => providers(src.TaggedTypes<LiteralProviderAttribute>());

        [MethodImpl(Inline), Op]
        static Index<LiteralProvider> providers(ReadOnlySpan<TaggedType<LiteralProviderAttribute>> types)
        {
            var count = types.Length;
            var dst = alloc<LiteralProvider>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var tagged = ref skip(types,i);
                var type = tagged.Type;
                var tag = tagged.Tag;
                seek(dst,i) = provider(text.ifempty(tag.Name, type.Name), type);
            }
            return dst;
        }
    }
}