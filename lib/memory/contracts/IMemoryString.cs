//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IMemoryString : INullity, IMeasured, IHashed, IAddressable
    {
        ReadOnlySpan<byte> Bytes {get;}

        ByteSize ISized.Size
            => Bytes.Length;

        BitWidth ISized.Width
            => Bytes.Length*8;

        uint IHashed.Hash
            => alg.hash.marvin(Bytes);

        bool INullity.IsEmpty
            => Bytes.Length == 0;

        bool INullity.IsNonEmpty
            => Bytes.Length != 0;
    }

    [Free]
    public interface IMemoryString<T> : IMemoryString
        where T : unmanaged
    {
        ReadOnlySpan<T> Cells {get;}

        ReadOnlySpan<byte> IMemoryString.Bytes
            => core.recover<T,byte>(Cells);

        int IMeasured.Length
            => Cells.Length;
    }
}