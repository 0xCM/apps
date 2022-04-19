//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class ApiWs : Workspace<ApiWs>
    {
        [MethodImpl(Inline)]
        public static ApiWs create(FS.FolderPath root)
            => new ApiWs(root);

        [MethodImpl(Inline)]
        ApiWs(FS.FolderPath root)
            : base(root)
        {
        }
    }
}