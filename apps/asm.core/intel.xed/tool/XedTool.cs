//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed partial class XedTool : ToolService<XedTool>
    {
        const string group = "xedtool";

        const string tool = "xed";

        public XedTool()
            : base(tool)
        {

        }

        public ScriptSpec DefineScript(string name, FS.FolderPath dst)
        {
            var @case = new ScriptSpec();
            @case.Name = name;
            @case.InputPath = input(dst,  binfile(name));
            @case.SummaryPath = output(dst, ToolFile(name, "summary", FileKind.Log));
            @case.DetailPath =  output(dst, ToolFile(name, "detail", FileKind.Log));
            return @case;
        }

        public void Render(ScriptSpec src, ITextEmitter dst)
        {
            const string SummaryFlags = "-isa-set -64";
            const string DetailFlags = "-v 4 -isa-set -64";
            dst.AppendLine("@echo off");
            dst.AppendLineFormat("set tool={0}", format(ToolPath()));
            dst.AppendLineFormat("set case={0}", src.Name);
            dst.AppendLineFormat("set SummaryFlags={0}", SummaryFlags);
            dst.AppendLineFormat("set DetailFlags={0}", DetailFlags);
            dst.AppendLineFormat("set SrcPath={0}", format(src.InputPath));
            dst.AppendLineFormat("set DetailPath={0}", format(src.DetailPath));
            dst.AppendLineFormat("set SummaryPath={0}", format(src.SummaryPath));
            dst.AppendLine("set CmdSpec=%tool% %SummaryFlags% -ir %SrcPath%");
            dst.AppendLine("echo CmdSpec:%CmdSpec%");
            dst.AppendLine("%CmdSpec% > %SummaryPath%");
            dst.AppendLine("set CmdSpec=%tool% %DetailFlags% -ir %SrcPath%");
            dst.AppendLine("echo CmdSpec:%CmdSpec%");
            dst.AppendLine("%CmdSpec% > %DetailPath%");
        }

        public string CreateScript(ScriptSpec src)
        {
            var buffer = text.buffer();
            Render(src, buffer);
            return buffer.Emit();
        }
    }
}