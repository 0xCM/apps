//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class ControlWs : Workspace<ControlWs>
    {
        [MethodImpl(Inline)]
        public static ControlWs create(FS.FolderPath root)
            => new ControlWs(root);

        [MethodImpl(Inline)]
        internal ControlWs(FS.FolderPath root)
            : base(root)
        {

        }
    }
}