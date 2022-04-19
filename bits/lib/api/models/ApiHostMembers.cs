//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiHostMembers
    {
        public ApiHostUri Host {get;}

        public ApiMembers Members {get;}

        [MethodImpl(Inline)]
        public ApiHostMembers(ApiHostUri host, ApiMembers members)
        {
            Host = host;
            Members = members;
        }

        public ReadOnlySpan<ApiMember> View
        {
            [MethodImpl(Inline)]
            get => Members.View;
        }
    }
}