//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;
    using static core;

    public sealed class ToolWs : Workspace<ToolWs>, IWorkspaceObselete
    {
        public static ToolWs create(FS.FolderPath home)
            => new ToolWs(home);

        public static SettingLookup config(FS.FilePath src)
        {
            var dst = list<Setting>();
            using var reader = src.LineReader(TextEncodingKind.Asci);
            while(reader.Next(out var line))
            {
                var content = span(line.Content);
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, Chars.Colon);
                    if(i > 0)
                    {
                        var name = text.format(SQ.left(content,i));
                        var value = text.format(SQ.right(content,i));
                        dst.Add(new Setting(name,value));
                    }
                }
            }
            return new SettingLookup(dst.ToArray());
        }

        public static IToolWs configure(IToolWs src)
        {
            var subdirs = src.Root.SubDirs();
            var counter = 0u;
            var dst = src.Inventory();
            var configs = list<ToolConfig>();
            foreach(var dir in subdirs)
            {
                var configCmd = dir + FS.file(ApiGranules.config, FS.Cmd);
                if(configCmd.Exists)
                {
                    var path =  dir + FS.folder(logs) + FS.file(ApiGranules.config, FS.Log);
                    if(path.Exists)
                    {
                        var result = parse(path.ReadText(), out ToolConfig c);
                        if(result)
                            configs.Add(c);
                    }
                }
            }
            return src.Configure(configs.ToArray());
        }

        public static Outcome parse(string src, out ToolConfig dst)
            => ToolWs.parse(src, out dst);

        public FS.FolderPath ToolHome(Actor id)
            => Root + FS.folder(id.Format());

        public FS.FilePath ConfigScript(Actor id)
            => ToolHome(id) + FS.file(ApiGranules.config, FS.Cmd);

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

        public  FS.FilePath Inventory()
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