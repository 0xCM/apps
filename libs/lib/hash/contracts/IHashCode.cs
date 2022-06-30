//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IHashCode
    {
        ReadOnlySpan<byte> Data {get;}

    }

    [Free]
    public interface IHashCode<T> : IHashCode, ITextual
        where T : unmanaged
     {
         T Value {get;}

        string ITextual.Format()
            => Value.ToString();

        ReadOnlySpan<byte> IHashCode.Data
            => core.bytes(Value);
     }

    [Free]
    public interface IHashCode<H,T> : IHashCode<T>, IEquatable<H>, IComparable<H>
        where H : unmanaged, IHashCode<H,T>
        where T : unmanaged
    {

    }
}