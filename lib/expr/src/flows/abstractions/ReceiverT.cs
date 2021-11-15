//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using System;

    public abstract class Receiver<T>
    {
        public abstract void Deposit(ReadOnlySpan<T> src);
    }
}