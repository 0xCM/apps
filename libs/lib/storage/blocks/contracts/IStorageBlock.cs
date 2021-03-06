//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public interface IStorageBlock : IHashed, INullity, ISized
    {
        Span<byte> Bytes {get;}

        BlockKind Kind
            => BlockKind.Bytes;

        bool INullity.IsEmpty
            => Bytes.Length == 0;

        bool INullity.IsNonEmpty
            => Bytes.Length != 0;

        Hash32 IHashed.Hash
            => alg.ghash.calc(Bytes);
    }

    public interface IStorageBlock<T> : IStorageBlock
        where T : unmanaged, IStorageBlock<T>
    {
        ByteSize ISized.Size
            => size<T>();

        BitWidth ISized.Width
            => width<T>();

        Span<byte> IStorageBlock.Bytes
            => bytes((T)this);
    }
}