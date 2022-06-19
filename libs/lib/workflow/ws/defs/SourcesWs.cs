//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class SourcesWs : Workspace<SourcesWs>
    {
        [MethodImpl(Inline)]
        public static SourcesWs create(FS.FolderPath root)
            => new SourcesWs(root);

        [MethodImpl(Inline)]
        internal SourcesWs(FS.FolderPath root)
            : base(root)
        {

        }
    }
}