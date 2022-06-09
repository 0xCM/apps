//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Defines a configuration for an identified tool
    /// </summary>
    [StructLayout(LayoutKind.Sequential), Record(TableId)]
    public struct ToolConfig
    {
        [Op]
        public static Outcome parse(string src, out ToolConfig dst)
        {
            dst = default;
            var result = Outcome.Success;
            var lines = Lines.read(src);
            if(lines.Length < ToolConfig.FieldCount)
                return (false, Tables.FieldCountMismatch.Format(ToolConfig.FieldCount, lines.Length));

            var settings = Settings.parse(slice(lines,1)).View;
            var i=0;

            DataParser.parse(skip(settings, i++).Value, out dst.Toolbase);
            DataParser.parse(skip(settings, i++).Value, out dst.ToolGroup);
            DataParser.parse(skip(settings, i++).Value, out dst.ToolId);
            DataParser.parse(skip(settings, i++).Value, out dst.ToolExe);
            DataParser.parse(skip(settings, i++).Value, out dst.InstallBase);

            DataParser.parse(skip(settings, i++).Value, out dst.ToolPath);
            DataParser.parse(skip(settings, i++).Value, out dst.ToolHome);
            DataParser.parse(skip(settings, i++).Value, out dst.ToolLogs);
            DataParser.parse(skip(settings, i++).Value, out dst.ToolDocs);

            DataParser.parse(skip(settings, i++).Value, out dst.ToolScripts);
            DataParser.parse(skip(settings, i++).Value, out dst.ToolConfigLog);
            DataParser.parse(skip(settings, i++).Value, out dst.ToolRunLog);
            DataParser.parse(skip(settings, i++).Value, out dst.ToolCmdLog);
            DataParser.parse(skip(settings, i++).Value, out dst.ToolHelpPath);
            DataParser.parse(skip(settings, i++).Value, out dst.ToolOut);

            return result;
        }

        public const string TableId = "tool.config";

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