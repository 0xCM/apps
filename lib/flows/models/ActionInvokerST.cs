//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class ActionInvoker<S,T> : IActionInvoker<S,T>
    {
        public Name ActionName {get;}

        public abstract T Invoke(S src);
    }
}