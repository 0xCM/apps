//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    public record class Project<P> : Entity<P>
        where P : Project<P>, new()
    {

    }

}