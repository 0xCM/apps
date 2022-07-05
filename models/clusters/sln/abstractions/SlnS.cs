//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public abstract record class Sln<S> : Cluster<S>
        where S : Sln<S>, new()
    {

    }
}