//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiAtomic;
    using static core;

    public sealed class ToolWs : Workspace<ToolWs>, IToolWs
    {
        public FS.FolderPath ToolHome(Actor id)
            => Root + FS.folder(id.Format());

        public FS.FilePath ConfigScript(Actor id)
            => ToolHome(id) + FS.file(ApiAtomic.config, FS.Cmd);

        Dictionary<Actor,ToolConfig> ConfigLookup;

        Index<ToolConfig> Configs;

        public ToolWs(FS.FolderPath root)
            : base(root)
        {
            ConfigLookup = dict<Actor,ToolConfig>();
            Configs = array<ToolConfig>();
        }

        public FS.FolderPath Home
            => Root;

        public FS.FolderPath ToolDocs(Actor tool)
            => ToolHome(tool) + FS.folder(docs);

        public FS.FolderPath Logs(Actor tool)
            => ToolHome(tool) + FS.folder(logs);

        public FS.FilePath ConfigPath(Actor tool)
            => ToolHome(tool) + FS.file(tool.Format(), FileKind.Config);

        public FS.FolderPath Scripts(Actor tool)
            => ToolHome(tool) + FS.folder(scripts);

        public FS.FilePath Script(Actor tool, string name)
            => Scripts(tool) + FS.file(name, FS.Cmd);

        public FS.FilePath Inventory()
            => Root + FS.folder(admin) + FS.file(inventory, FS.Txt);

        public ReadOnlySpan<ToolConfig> Configured
        {
            [MethodImpl(Inline)]
            get => Configs;
        }

        public bool Settings(Actor tool, out ToolConfig dst)
            => ConfigLookup.TryGetValue(tool, out dst);

        public void Configure(Actor tool, in ToolConfig src)
            => ConfigLookup[tool] = src;

        public ToolWs Configure(ToolConfig[] src)
        {
            Configs = src;
            ConfigLookup = src.Select(x => (x.Tool, x)).ToDictionary();
            return this;
        }
    }
}