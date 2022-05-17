//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IMemoryString : INullity, IMeasured, IHashed
    {
        ReadOnlySpan<byte> Bytes {get;}

        MemoryAddress Address {get;}

        uint IHashed.Hash
            => alg.hash.marvin(Bytes);

        bool INullity.IsEmpty
            => Bytes.Length == 0;

        bool INullity.IsNonEmpty
            => Bytes.Length != 0;
    }

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