//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
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

         uint Width
            => core.width<T>();
     }

    [Free]
    public interface IHashCode<C,U> : IHashCode<U>, IDataType<C>
        where C : unmanaged, IHashCode<C,U>
        where U : unmanaged
    {
        U Primitive {get;}
    }
}