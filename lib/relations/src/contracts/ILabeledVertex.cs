//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ILabeledVertex : IVertex
    {
        Label Name {get;}
    }

    [Free]
    public interface ILabeledVertex<V> : ILabeledVertex
    {
        V Value {get;}
    }
}