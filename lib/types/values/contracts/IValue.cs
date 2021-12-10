//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;


    [Free]
    public interface IValue : ITyped
    {
        dynamic Value {get;}
    }

    [Free]
    public interface IValue<T> : IValue
    {
        new T Value {get;}

        dynamic IValue.Value
            => Value;
    }

    [Free]
    public interface IValue<K,T> : IValue<T>, IKinded<K>
        where K : unmanaged
    {

    }
}