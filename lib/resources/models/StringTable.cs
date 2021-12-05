//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using api = StringTables;

    public class StringTable
    {
        public Identifier Name {get;}

        public readonly string Content;

        readonly Index<uint> _Offsets;

        readonly Index<Identifier> _Identifiers;

        [MethodImpl(Inline)]
        public StringTable(Identifier name, string src, Index<uint> offsets, Identifier[] identifiers)
        {
            Name = name;
            Content = src;
            _Offsets = offsets;
            _Identifiers = identifiers;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<char> Entry(int index)
            => api.chars(this, index);

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

        [MethodImpl(Inline)]
        public ref readonly Identifier Identifier(int index)
            => ref _Identifiers[index];

        [MethodImpl(Inline)]
        public ref readonly Identifier Identifier(uint index)
            => ref _Identifiers[index];

        public uint EntryCount
        {
            [MethodImpl(Inline)]
            get => _Offsets.Count;
        }

        public ReadOnlySpan<char> Data
        {
            [MethodImpl(Inline)]
            get => Content;
        }

        public ReadOnlySpan<uint> Offsets
        {
            [MethodImpl(Inline)]
            get => _Offsets.View;
        }

        public ReadOnlySpan<Identifier> Identifiers
        {
            [MethodImpl(Inline)]
            get => _Identifiers.View;
        }

        public uint[] OffsetStorage
        {
            [MethodImpl(Inline)]
            get => _Offsets.Storage;
        }

        public string Format()
            => api.format(this);

        public string Format(uint margin)
            => api.format(this, margin);

        public override string ToString()
            => Format();
    }
}