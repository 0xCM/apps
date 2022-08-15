//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    using Contracts;

    public abstract record class Ws<W> : Entity<W>
        where W : Ws<W>, new()
    {

    }
}