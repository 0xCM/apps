//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public interface ICharBlock<T> : ITextual, IComparable<T>, IEquatable<T>, IStorageBlock<T>, ICellBlock<char>, IHashed, INullity
        where T : unmanaged, ICharBlock<T>
    {
        BlockKind IStorageBlock.Kind
            => BlockKind.Char16;

        Span<char> Data {get;}

        ReadOnlySpan<char> String {get;}

        int Length {get;}

        uint Capacity {get;}

        bool INullity.IsEmpty
            => Length == 0;

        bool INullity.IsNonEmpty
            => Length != 0;

        uint IHashed.Hash
            => alg.ghash.calc(String);

        ByteSize IStorageBlock.Size
            => Length*2;

        Span<char> ICellBlock<char>.Cells
            => Data;

        Span<byte> IStorageBlock.Bytes
            => recover<byte>(Data);

        int IComparable<T>.CompareTo(T src)
            => Data.SequenceCompareTo(src.Data);

        bool IEquatable<T>.Equals(T src)
            => Data.SequenceEqual(src.Data);

        ref char First
            => ref first(Data);
    }
}