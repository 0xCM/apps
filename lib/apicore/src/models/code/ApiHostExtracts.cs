//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ApiHostExtracts : IIndex<ApiMemberExtract>
    {
        public ApiHostUri Host {get;}

        readonly Index<ApiMemberExtract> Blocks;

        [MethodImpl(Inline)]
        public ApiHostExtracts(ApiHostUri host, Index<ApiMemberExtract> blocks)
        {
            Host = host;
            Blocks = blocks;
        }

        public ReadOnlySpan<ApiMemberExtract> View
        {
            [MethodImpl(Inline)]
            get => Blocks.View;
        }

        public ApiMemberExtract[] Storage
        {
            [MethodImpl(Inline)]
            get => Blocks.Storage;
        }

        public uint BlockCount
        {
            [MethodImpl(Inline)]
            get => Blocks.Count;
        }

        public ApiHostExtracts Sort()
        {
            Blocks.Sort();
            return this;
        }
    }
}