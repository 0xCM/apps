//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class TableWs : Workspace<TableWs>
    {
        [MethodImpl(Inline)]
        public static TableWs create(FS.FolderPath root)
            => new TableWs(root);

        [MethodImpl(Inline)]
        internal TableWs(FS.FolderPath root)
            : base(root)
        {

        }
    }
}