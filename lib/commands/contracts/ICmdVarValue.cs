//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ICmdVarValue : ITextual, INullity
    {

    }

    [Free]
    public interface ICmdVarValue<T> : ICmdVarValue, IContented<T>
    {

    }
}