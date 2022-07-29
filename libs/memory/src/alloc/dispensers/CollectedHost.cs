//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class CollectedHost
    {
        public readonly ApiHostMembers Resolved;

        public readonly ReadOnlySeq<ApiEncoded> Blocks;

        public CollectedHost(ApiHostMembers resolved, ReadOnlySeq<ApiEncoded> blocks)
        {
            Resolved = resolved;
            Blocks = blocks;
        }

        public ApiHostUri Host
        {
            [MethodImpl(Inline)]
            get => Resolved.Host;
        }
    }
}