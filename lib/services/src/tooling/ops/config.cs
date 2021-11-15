//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Tooling
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
    }
}