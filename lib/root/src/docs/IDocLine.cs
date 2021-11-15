//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IDocLine
    {

    }

    [Free]
    public interface IDocLine<T> : IDocLine
        where T : struct, IDocLine<T>
    {

    }
}