//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class ProjectDbWs : Workspace<ProjectDbWs>, IProjectDb
    {
        public Settings ProjectSettings => Settings.Empty;

        [MethodImpl(Inline)]
        public static ProjectDbWs create(FS.FolderPath root)
            => new ProjectDbWs(root);

        [MethodImpl(Inline)]
        internal ProjectDbWs(FS.FolderPath root)
            : base(root)
        {

        }
    }
}