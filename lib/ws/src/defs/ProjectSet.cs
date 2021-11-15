//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public sealed class ProjectSet : Workspace<ProjectSet>, IProjectSet
    {
        [MethodImpl(Inline)]
        public static ProjectSet create(FS.FolderPath home)
            => new ProjectSet(home);

        Dictionary<ProjectId,ProjectConfig> ConfigLookup;

        public ProjectSet(FS.FolderPath src)
            : base(src)
        {
            ConfigLookup = dict<ProjectId,ProjectConfig>();
        }

        public bool Settings(ProjectId id, out ProjectConfig dst)
            => ConfigLookup.TryGetValue(id, out dst);

        public void Configure(ProjectId id, in ProjectConfig src)
            => ConfigLookup[id] = src;
    }
}