//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class ToolConfigs
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

        public static ToolConfigs create(ToolConfig[] src)
            => new ToolConfigs(src);

        readonly Index<ToolConfig> _Tools;

        readonly Dictionary<ToolId,ToolConfig> Lookup;

        internal ToolConfigs(ToolConfig[] tools)
        {
            _Tools = tools;
            Lookup = tools.Select(t => (t.ToolId, t)).ToDictionary();
        }

        public bool Config(ToolId id, out ToolConfig config)
            => Lookup.TryGetValue(id,out config);

        public ReadOnlySpan<ToolConfig> Configured
        {
            [MethodImpl(Inline)]
            get => _Tools.View;
        }

        public uint ToolCount
        {
            [MethodImpl(Inline)]
            get => _Tools.Count;
        }
    }
}