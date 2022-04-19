//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IProducer
    {

    }

    [Free]
    public interface IProducer<T> : IProducer
    {

    }

    [Free]
    public interface IProducer<S,T> : IProducer<T>
    {

    }
}