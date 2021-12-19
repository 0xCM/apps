//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    public interface ISeqReceiver<T>
    {
        void Deposit(ReadOnlySpan<T> src);
    }
}