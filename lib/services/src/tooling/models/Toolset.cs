//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class Toolset
    {
        public FS.FolderPath InstallBase {get;}

        public Index<ToolId> Members {get;}

        [MethodImpl(Inline)]
        public Toolset(FS.FolderPath @base, ToolId[] members)
        {
            InstallBase = @base;
            Members = members;
        }

        public Index<ToolDeployment> Deployments
            => Members.Select(x => new ToolDeployment(x,InstallBase + FS.file(x.Format(), FS.Exe)));

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Members.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Members.IsNonEmpty;
        }

        public static Toolset Empty => new Toolset(FS.FolderPath.Empty, sys.empty<ToolId>());
    }
}