//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using api = StringTables;

    public class StringTable
    {
        public readonly StringTableSpec Spec;

        public readonly Index<string> Names;

        public readonly Index<char> Content;

        public readonly Index<uint> Offsets;

        [MethodImpl(Inline)]
        public StringTable(StringTableSpec spec, char[] src, Index<uint> offsets, string[] names)
        {
            Spec = spec;
            Content = src;
            Offsets = offsets;
            Names = names;
        }

        [MethodImpl(Inline)]
        public StringTable(StringTableSpec spec, char[] src, Index<uint> offsets)
        {
            Spec = spec;
            Content = src;
            Offsets = offsets;
            Names = sys.empty<string>();
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Entry(int index)
            => api.entry(this, index);

        public ReadOnlySpan<char> this[int index]
        {
            [MethodImpl(Inline)]
            get => Entry(index);
        }

        public ReadOnlySpan<char> this[uint index]
        {
            [MethodImpl(Inline)]
            get => Entry((int)index);
        }

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => Offsets.Count;
        }
    }
}