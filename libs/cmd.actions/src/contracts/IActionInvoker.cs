//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IActionInvoker
    {
    }

    public interface IActionInvoker<S,T> : IActionInvoker
    {
        T Invoke(S src);
    }
}