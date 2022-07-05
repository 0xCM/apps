//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public record class CmdProject<P> : Project<P>
        where P : CmdProject<P>, new()
    {

    }

}