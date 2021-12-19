//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
using System;

namespace Z0
{
    [Actor]
    public abstract class Actor<A> : Actor
        where A : Actor<A>,new()
    {
        protected Actor(Identifier name)
            : base(name)
        {

        }
    }
}