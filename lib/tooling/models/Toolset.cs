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

        public Index<ToolProfile> Profiles {get;}

        public Index<ToolDeployment> Deployments {get;}

        [MethodImpl(Inline)]
        public Toolset(FS.FolderPath @base, ToolProfile[] profiles)
        {
            InstallBase = @base;
            Profiles = profiles;
            Deployments = Profiles.Select(x => new ToolDeployment(x.Id, InstallBase + FS.file(x.Id.Format(), FS.Exe)));
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Profiles.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Profiles.IsNonEmpty;
        }

        public static Toolset Empty => new Toolset(FS.FolderPath.Empty, sys.empty<ToolProfile>());
    }
}