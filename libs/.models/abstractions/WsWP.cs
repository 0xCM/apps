//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    using Contracts;

    public abstract record class Ws<W,P> : Ws<W>
        where W : Ws<W,P>,new()
        where P : IProject, new()
    {

    }
}