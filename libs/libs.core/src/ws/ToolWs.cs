//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static ApiGranules;

    public sealed class ToolWs : Workspace<ToolWs>, IToolWs
    {
        [MethodImpl(Inline)]
        public static ToolWs create(IEnvProvider src)
            => new ToolWs(src);

        [MethodImpl(Inline)]
        public static ToolWs create(FS.FolderPath src)
            => new ToolWs(src);

        Dictionary<ToolId,ToolConfig> ConfigLookup;

        Index<ToolConfig> Configs;

        public ToolWs(FS.FolderPath root)
            : base(root)
        {
            ConfigLookup = dict<ToolId,ToolConfig>();
            Configs = array<ToolConfig>();

        }

        public DbSources Logs()
            => new DbSources(Root, logs);

        ToolWs(IEnvProvider src)
            : base(src.Env.Toolbase)
        {
            ConfigLookup = dict<ToolId,ToolConfig>();
            Configs = array<ToolConfig>();
        }

        public ReadOnlySpan<ToolConfig> Configured
        {
            [MethodImpl(Inline)]
            get => Configs;
        }

        FS.FolderPath IToolWs.Toolbase
        {
            [MethodImpl(Inline)]
            get => Root;
        }

        public bool Settings(ToolId id, out ToolConfig dst)
            => ConfigLookup.TryGetValue(id, out dst);

        public void Configure(ToolId id, in ToolConfig src)
            => ConfigLookup[id] = src;

        public IToolWs Configure(ToolConfig[] src)
        {
            Configs = src;
            ConfigLookup = src.Select(x => (x.ToolId, x)).ToDictionary();
            return this;
        }

    }
}