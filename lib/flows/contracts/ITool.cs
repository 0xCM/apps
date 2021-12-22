//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITool
    {
        ToolId ToolId {get;}
    }

    [Free]
    public interface ITool<T> : ITool, IActor<T>
        where T : ITool<T>, new()
    {

    }
}