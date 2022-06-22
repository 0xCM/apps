//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static ApiGranules;
    using static core;

    public sealed class ToolWs : Workspace<ToolWs>, IWorkspace
    {
        public static ref readonly ToolWs Service => ref AppDb.ToolWs;

        public static Settings settings(FS.FilePath src)
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
            return new Settings(dst.ToArray());
        }

        public static IToolWs configure(IToolWs src)
        {
            var subdirs = src.Root.SubDirs();
            var counter = 0u;
            var dst = src.Inventory();
            var configs = list<ToolConfig>();
            foreach(var dir in subdirs)
            {
                var configCmd = dir + FS.file(config, FS.Cmd);
                if(configCmd.Exists)
                {
                    var path =  dir + FS.folder(logs) + FS.file(config, FS.Log);
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

        public FS.FolderPath ToolHome(ToolId id)
            => Root + FS.folder(id.Format());

        public FS.FilePath ConfigScript(ToolId id)
            => ToolHome(id) + FS.file(config, FS.Cmd);

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

        public FS.FilePath Config(ToolId id)
            => ToolHome(id) + FS.file(id,FileKind.Config);

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

        public FS.FilePath Inventory()
            => Root + FS.folder(admin) + FS.file(inventory, FS.Txt);

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