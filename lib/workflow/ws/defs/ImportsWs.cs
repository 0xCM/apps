//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class ImportsWs : Workspace<ImportsWs>
    {
        [MethodImpl(Inline)]
        public static ImportsWs create(FS.FolderPath root)
            => new ImportsWs(root);

        [MethodImpl(Inline)]
        internal ImportsWs(FS.FolderPath root)
            : base(root)
        {

        }
    }
}