//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public record class Project<P> : Component<P>
        where P : Project<P>, new()
    {

    }

}