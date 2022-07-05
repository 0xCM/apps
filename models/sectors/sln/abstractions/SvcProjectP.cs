//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public abstract record class SvcProject<P> : Project<P>
        where P : SvcProject<P>, new()
    {

    }
}