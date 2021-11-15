//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    public interface ICharBlock<T> : ITextual, IComparable<T>, IEquatable<T>, IDataBlock<T>, ICellBlock<char>, IHashed
        where T : unmanaged, ICharBlock<T>
    {
        Span<char> Data {get;}

        ReadOnlySpan<char> String {get;}

        int Length {get;}

        uint Capacity {get;}

        uint IHashed.Hash
            => alg.hash.calc(String);

        ByteSize IDataBlock.Size
            => Length*2;

        Span<char> ICellBlock<char>.Cells
            => Data;

        Span<byte> IDataBlock.Bytes
            => recover<byte>(Data);

        int IComparable<T>.CompareTo(T src)
            => Data.SequenceCompareTo(src.Data);

        bool IEquatable<T>.Equals(T src)
            => Data.SequenceEqual(src.Data);

        ref char First
            => ref first(Data);
    }
}