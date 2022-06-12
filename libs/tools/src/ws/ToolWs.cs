//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static WsAtoms;

    public sealed class ToolWs : Workspace<ToolWs>, IWorkspace
    {
        public FS.FolderPath ToolHome(ToolId id)
            => Root + FS.folder(id.Format());

        public FS.FilePath ConfigScript(ToolId id)
            => ToolHome(id) + FS.file("config", FS.Cmd);

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

        public FS.FolderPath ToolDocs(ToolId id)
            => ToolHome(id) + FS.folder(docs);

        public FS.FolderPath Logs(ToolId id)
            => ToolHome(id) + FS.folder(logs);

        public FS.FolderPath Scripts(ToolId id)
            => ToolHome(id) + FS.folder(scripts);

        public FS.FilePath Script(ToolId tool, string id)
            => Scripts(tool) + FS.file(id,FS.Cmd);

        public FS.FilePath ConfigLog(ToolId id)
            => Logs(id) + FS.file(config, FS.Log);

        public ToolWs(IRootedArchive root)
            : base(root.Root)
        {
            ConfigLookup = dict<ToolId,ToolConfig>();
            Configs = array<ToolConfig>();
        }

        public DbSources Logs()
            => new DbSources(Root, ApiGranules.logs);

        ToolWs(IEnvProvider src)
            : base(src.Env.Toolbase)
        {
            ConfigLookup = dict<ToolId,ToolConfig>();
            Configs = array<ToolConfig>();
        }

        public FS.FilePath Inventory()
            => Root + FS.folder(admin) + FS.file(inventory, FS.Txt);

        // public new DbSources ToolHome(ToolId id)
        //     => new DbSources(Toolbase, id.Format());
        public ReadOnlySpan<ToolConfig> Configured
        {
            [MethodImpl(Inline)]
            get => Configs;
        }

        public IDbSources Toolbase
            => new DbSources(Root);

        public bool Settings(ToolId id, out ToolConfig dst)
            => ConfigLookup.TryGetValue(id, out dst);

        public void Configure(ToolId id, in ToolConfig src)
            => ConfigLookup[id] = src;

        public ToolWs Configure(ToolConfig[] src)
        {
            Configs = src;
            ConfigLookup = src.Select(x => (x.ToolId, x)).ToDictionary();
            return this;
        }
    }
}