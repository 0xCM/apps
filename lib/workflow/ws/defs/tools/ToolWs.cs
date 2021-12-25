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

    public sealed class ToolWs : Workspace<ToolWs>, IToolWs
    {
        [MethodImpl(Inline)]
        public static ToolWs create(FS.FolderPath root)
            => new ToolWs(root);

        Dictionary<ToolId,ToolConfig> ConfigLookup;

        Index<ToolConfig> Configs;

        internal ToolWs(FS.FolderPath root)
            : base(root)
        {
            ConfigLookup = dict<ToolId,ToolConfig>();
            Configs = array<ToolConfig>();
            Toolbase = Env.load().Toolbase;

        }

        public IToolWs Configure(ToolConfig[] src)
        {
            Configs = src;
            ConfigLookup = src.Select(x => (x.ToolId, x)).ToDictionary();
            return this;
        }

        public ReadOnlySpan<ToolConfig> Configured
        {
            get => Configs;
        }

        public FS.FolderPath Toolbase {get;}

        public bool Settings(ToolId id, out ToolConfig dst)
            => ConfigLookup.TryGetValue(id, out dst);

        public void Configure(ToolId id, in ToolConfig src)
            => ConfigLookup[id] = src;
    }
}