//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ILocatedSource : ISourceCode, IMemoryString
    {
        MemoryAddress Location {get;}

        MemoryAddress IMemoryString.Address
            => Location;

        ReadOnlySpan<byte> IMemoryString.Bytes
            => Data;
    }

    public interface ILocatedSource<T> : ILocatedSource, ISourceCode<T>, IMemoryString<T>
        where T : unmanaged, IEquatable<T>
    {
    }

    public interface ILocatedSource<H,T> : ISourceCode<H,T>, ILocatedSource<T>
        where T : unmanaged, IEquatable<T>
        where H : ISourceCode<H,T>
    {

    }
}