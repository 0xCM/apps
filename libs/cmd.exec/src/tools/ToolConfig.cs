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
    public interface IToolWs : IWorkspace
    {
        IToolWs Configure(ToolConfig[] src);

        ReadOnlySpan<ToolConfig> Configured {get;}

        IDbSources Toolbase {get;}

        FS.FilePath Inventory()
            => Root + FS.folder(admin) + FS.file(inventory, FS.Txt);

        new DbSources ToolHome(ToolId id)
            => new DbSources(Toolbase, id.Format());
    }

    /// <summary>
    /// Defines a configuration for an identified tool
    /// </summary>
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct ToolConfig
    {
        const string TableId = "tool.config";

        public const byte FieldCount = 15;

        /// <summary>
        /// The tool control base directory
        /// </summary>
        public FS.FolderPath Toolbase;

        /// <summary>
        /// The group to which the tool belongs, if any
        /// </summary>
        public string ToolGroup;

        /// <summary>
        /// The tool identifier
        /// </summary>
        public ToolId ToolId;

        /// <summary>
        /// The executable filename without the directory path
        /// </summary>
        public FS.FileName ToolExe;

        /// <summary>
        /// The tool installation directory where the <see cref='ToolExe'/> is found
        /// </summary>
        public FS.FolderPath InstallBase;

        /// <summary>
        /// The full path to the tool, computed from the <see cref='ToolExe'/> and <see cref='InstallBase'/>
        /// </summary>
        public FS.FilePath ToolPath;

        /// <summary>
        /// The toolspace directory
        /// </summary>
        public FS.FolderPath ToolHome;

        /// <summary>
        /// The tool log directory with default location {ToolHome}/logs
        /// </summary>
        public FS.FolderPath ToolLogs;

        /// <summary>
        /// The tool documentation directory with default location {ToolHome}/docs
        /// </summary>
        public FS.FolderPath ToolDocs;

        /// <summary>
        /// The tool script directory with default location {ToolHome}/scripts
        /// </summary>
        public FS.FolderPath ToolScripts;

        /// <summary>
        /// The path to the tool configuration log, typically {ToolLogs}/config.log
        /// </summary>
        public FS.FilePath ToolConfigLog;

        /// <summary>
        /// The path to the tool execution log, typically {ToolLogs}/{ToolId}-run.log
        /// </summary>
        public FS.FilePath ToolRunLog;

        /// <summary>
        /// The path to the tool command log, typically {ToolLogs}/{ToolId}-cmd.log
        /// </summary>
        public FS.FilePath ToolCmdLog;

        /// <summary>
        /// The path to the primary tool help file, typically {ToolHome}/docs/{ToolId}.help
        /// </summary>
        public FS.FilePath ToolHelpPath;

        /// <summary>
        /// The path to the defalt tool output directory
        /// </summary>
        public FS.FilePath ToolOut;
    }
}