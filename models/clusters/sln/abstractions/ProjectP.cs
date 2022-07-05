//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public sealed record class Project<P> : Model<P>
        where P : Partition<P>, new()
    {

    }

}