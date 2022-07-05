//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public abstract record class Cluster<C> : Cluster, ICluster<C>
        where C : Cluster<C>, new()
    {

    }

}