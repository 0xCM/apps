//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class AsmWs : IWorkspaceObselete<AsmWs>
    {
        [MethodImpl(Inline)]
        public static IWorkspaceObselete create(FS.FolderPath root)
            => new AsmWs(root);

        public FS.FolderPath Root {get;}

        [MethodImpl(Inline)]
        internal AsmWs(FS.FolderPath root)
        {
            Root = root;
        }
    }
}