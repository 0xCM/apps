//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models.Clusters
{
    public abstract record class Svc<S> : Model<S>
        where S : Svc<S>, new()
    {

    }


}