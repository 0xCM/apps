//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public interface ICharBlock : ITextual, IStorageBlock, ICellBlock<char>
    {
        BlockKind IStorageBlock.Kind
            => BlockKind.Char16;

        Span<char> Data {get;}

        ReadOnlySpan<char> String {get;}

        int Length {get;}

        uint Capacity {get;}

        Span<char> ICellBlock<char>.Cells
            => Data;

        ref char First
            => ref first(Data);
    }

    public interface ICharBlock<T> : ICharBlock, IComparable<T>, IEquatable<T>, IStorageBlock<T>
        where T : unmanaged, ICharBlock<T>
    {
        ByteSize IStorageBlock.Size
            => Length*2;

        int IComparable<T>.CompareTo(T src)
            => Data.SequenceCompareTo(src.Data);

        bool IEquatable<T>.Equals(T src)
            => Data.SequenceEqual(src.Data);

        Span<byte> IStorageBlock.Bytes
            => recover<byte>(Data);
    }
}