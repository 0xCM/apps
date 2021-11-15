//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class LogWs : Workspace<LogWs>
    {
        [MethodImpl(Inline)]
        public static LogWs create(FS.FolderPath root)
            => new LogWs(root);

        [MethodImpl(Inline)]
        internal LogWs(FS.FolderPath root)
            : base(root)
        {

        }
    }
}