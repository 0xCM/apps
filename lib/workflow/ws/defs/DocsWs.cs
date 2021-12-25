//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class DocsWs : Workspace<DocsWs>
    {
        [MethodImpl(Inline)]
        public static DocsWs create(FS.FolderPath root)
            => new DocsWs(root);

        [MethodImpl(Inline)]
        internal DocsWs(FS.FolderPath root)
            : base(root)
        {

        }
    }
}