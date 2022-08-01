//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    public abstract record class Sln<S> : Entity<S>, ISln<S>
        where S : Sln<S>, new()
    {

    }
}