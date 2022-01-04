//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface IMemoryString : INullity, ITextual, IMeasured, IHashed
    {
        ReadOnlySpan<char> Data {get;}

        MemoryAddress Address {get;}

        uint IHashed.Hash
            => alg.hash.marvin(Data);

        int IMeasured.Length
            => Data.Length;

        bool INullity.IsEmpty
            => Data.Length == 0;

        bool INullity.IsNonEmpty
            => Data.Length != 0;

        ByteSize Size => Data.Length*2;

        string ITextual.Format()
            => new string(Data);
    }

    public interface IMemoryString<T> : IMemoryString, IEquatable<T>, IComparable<T>
        where T : unmanaged, IMemoryString<T>

    {
        bool IEquatable<T>.Equals(T src)
            => text.equals(Data,src.Data);

        int IComparable<T>.CompareTo(T src)
            => Data.CompareTo(src.Data, StringComparison.InvariantCulture);
    }
}