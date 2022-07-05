//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Models
{
    public interface ICluster : IModel
    {

    }

    public interface IPartition<P> : ICluster, IModel<P>
        where P : IPartition<P>, new()
    {

    }
}