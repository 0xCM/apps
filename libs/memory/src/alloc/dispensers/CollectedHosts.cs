//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class CollectedHosts : Seq<CollectedHosts, CollectedHost>
    {
        public CollectedHosts()
        {

        }

        public CollectedHosts(CollectedHost[] src)
            : base(src)
        {

        }

        public static implicit operator CollectedHosts(CollectedHost[] src)
            => new CollectedHosts(src);

        public static implicit operator CollectedHosts(Index<CollectedHost> src)
            => new CollectedHosts(src);
    }
}