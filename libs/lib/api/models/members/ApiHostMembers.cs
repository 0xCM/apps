//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class ApiHostMembers
    {
        public readonly ApiHostUri Host;

        public readonly ApiMembers Members;

        [MethodImpl(Inline)]
        public ApiHostMembers(ApiHostUri host, ApiMembers members)
        {
            Host = host;
            Members = members;
        }
    }
}