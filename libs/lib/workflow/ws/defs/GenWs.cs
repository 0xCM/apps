//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class GenWs : Workspace<GenWs>
    {
        [MethodImpl(Inline)]
        public static GenWs create(FS.FolderPath root)
            => new GenWs(root);


        [MethodImpl(Inline)]
        internal GenWs(FS.FolderPath root)
            : base(root)
        {
        }
    }
}