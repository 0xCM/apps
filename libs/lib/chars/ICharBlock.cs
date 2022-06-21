//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public interface ICharBlock : ICharSeq<char>,  ITextual, IStorageBlock, ICharSeq
    {
        Span<char> Data {get;}

        ReadOnlySpan<char> String {get;}

        ReadOnlySpan<char> ICellular<char>.Cells
            => Data;

        ref char First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        new ref char this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        new ref char this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,index);
        }

        BlockKind IStorageBlock.Kind
            => BlockKind.Char16;

        Hash32 IHashed.Hash
            => hash(Data);

        string ITextual.Format()
            => new string(Data);

        bool ICharSeq.IsBlank
            => text.blank(Data);

        bool INullity.IsEmpty
            => text.empty(Data);

        bool INullity.IsNonEmpty
            => text.nonempty(Data);
    }

    public interface ICharBlock<T> : ICharBlock, IComparable<T>, IEquatable<T>, IStorageBlock<T>
        where T : unmanaged, ICharBlock<T>
    {
        ByteSize IStorageBlock.Size
            => Length*2;

        int IByteSeq.Capacity
            => Length*2;

        Span<byte> IStorageBlock.Bytes
            => recover<byte>(Data);

        int IComparable<T>.CompareTo(T src)
            => Cells.SequenceCompareTo(src.Cells);

        bool IEquatable<T>.Equals(T src)
            => Cells.SequenceEqual(src.Cells);

        bool ICharSeq.IsNull
            => Data.SequenceEqual(default(T).Data);
    }
}