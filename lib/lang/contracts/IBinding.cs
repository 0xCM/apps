//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    public interface IBinding : IExpr
    {
        Value<dynamic> Value {get;}
    }

    [Free]
    public interface IBinding<T> : IBinding
    {
        new Value<T> Value {get;}

        Value<dynamic> IBinding.Value
            => new Value<dynamic>(Value.Content);
    }
}