//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiHostCode
    {
        public ApiHostMembers Resolved;

        public ReadOnlySeq<CollectedEncoding> Blocks;

        public ApiHostCode(ApiHostMembers resolved, ReadOnlySeq<CollectedEncoding> blocks)
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