//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct CliRowKeys : IIndex<CliRowKey>
    {
        readonly Index<CliRowKey> Data;

        public CliTableKind Table {get;}

        [MethodImpl(Inline)]
        public CliRowKeys(Index<CliRowKey> src, CliTableKind table = default)
        {
            Data = src;
            Table = table;
        }

        public ref CliRowKey First
        {
            [MethodImpl(Inline)]
            get => ref Data.First;
        }
        public ref CliRowKey this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref CliRowKey this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }
        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public ReadOnlySpan<CliRowKey> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public CliRowKey[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        [MethodImpl(Inline)]
        public static implicit operator CliRowKeys(CliRowKey[] src)
            => new CliRowKeys(src);

        [MethodImpl(Inline)]
        public static implicit operator CliRowKeys((CliRowKey[] keys, CliTableKind table) src)
            => new CliRowKeys(src.keys, src.table);
    }
}