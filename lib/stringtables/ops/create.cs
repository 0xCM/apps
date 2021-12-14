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

    partial class StringTables
    {
        [Op]
        public static StringTable create(StringTableSyntax syntax, ReadOnlySpan<string> src, Identifier[] identifiers)
        {
            var count = src.Length;
            var offset = 0u;
            var offsets = alloc<uint>(count);
            var chars = alloc<char>(text.length(src));
            ref var joined = ref first(chars);
            ref var cuts = ref first(offsets);
            var j = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var entry = ref skip(src,i);
                seek(cuts,i) = j;
                copy(entry, ref j, chars);
            }
            return new StringTable(syntax, new string(chars), offsets, identifiers);
        }

        public static StringTable create<K>(StringTableSyntax syntax, Symbols<K> src)
            where K : unmanaged
        {
            var count = src.Length;
            var expressions = span<string>(count);
            var identifiers = alloc<Identifier>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var sym = ref src[i];
                seek(expressions,i) = sym.Expr.Format();
                seek(identifiers,i) = sym.Name;
            }
            return create(syntax, @readonly(expressions), identifiers);
        }

        public static StringTable create(StringTableSpec spec, ReadOnlySpan<ListItem<string>> src)
        {
            var count = src.Length;
            var strings = span<string>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(src,i);
                seek(strings, entry.Key) = entry.Value;
            }

            var offset = 0u;
            var offsets = alloc<uint>(count);
            var chars = alloc<char>(text.length(strings));
            ref var joined = ref first(chars);
            ref var cuts = ref first(offsets);
            var j = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var entry = ref skip(src,i);
                seek(cuts, i) = j;
                copy(entry.Value, ref j, chars);
            }
            return new StringTable(spec.Syntax, new string(chars), offsets, src.Map(x => new Identifier(x.Value)).ToArray());
        }

        [MethodImpl(Inline), Op]
        static ulong copy(ReadOnlySpan<char> src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            var count = src.Length;
            for(var j=0; j<count; j++)
                seek(dst,i++) = skip(src,j);
            return i - i0;
        }
    }
}