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
        public static StringTable create(ReadOnlySpan<string> lines, Identifier name, char delimiter)
        {
            var buffer = list<string>();
            for(var i=0; i<lines.Length; i++)
                buffer.AddRange(skip(lines,i).SplitClean(delimiter).Select(x => x.Trim()));
            var entries = buffer.ViewDeposited();
            var table = create(name, entries, identifiers(lines,delimiter));
            var count = Require.equal(buffer.Count, (int)table.EntryCount);
            for(var i=0u; i<count; i++)
            {
                var data = table[i];
                ref readonly var s0 = ref skip(entries,i);
                var s1 = new string(data);
                Require.equal(s0, s1);
            }
            return table;
        }

        public static StringTable create<K>(Symbols<K> src, Identifier name)
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
            return create(name, @readonly(expressions), identifiers);
        }

        [Op]
        public static StringTable create(Identifier name, ReadOnlySpan<string> src, Identifier[] identifiers)
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
            return new StringTable(name, new string(chars), offsets, identifiers);
        }

        public static StringTable create(Identifier name, ReadOnlySpan<ListItem<string>> src)
        {
            var count = src.Length;
            var strings = span<string>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(src,i);
                seek(strings, entry.Id) = entry.Content;
            }
            return create(name,strings, src.Map(x => new Identifier(x.Content)).ToArray());
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

        static Identifier[] identifiers(ReadOnlySpan<string> lines, char delimiter)
        {
            var identifiers = list<Identifier>();
            for(var i=0; i<lines.Length; i++)
            {
                ref readonly var line = ref skip(lines,i);
                var cells = line.SplitClean(delimiter).Select(x => x.Trim());
                for(var j=0; j<cells.Length; j++)
                    identifiers.Add(skip(cells,j));
            }
            return identifiers.ToArray();
        }
    }
}