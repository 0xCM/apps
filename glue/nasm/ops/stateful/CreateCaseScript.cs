//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Tools
{
    partial class Nasm
    {
        public NasmCaseScript CreateCaseScript(Identifier name, FS.FolderPath dst)
        {
            var @case = new NasmCase();
            @case.CaseId = name;
            @case.SourcePath = input(dst,  FS.file(name.Format(), FS.Asm));
            @case.BinPath = output(dst, FS.file(name.Format(), FS.Bin));
            @case.ListPath = FS.path(string.Format("{0}.list.asm", @case.BinPath));
            return CreateCaseScript(@case, Script(dst, FS.file(name.Format(), FS.Cmd)));
        }

        public NasmCaseScript CreateCaseScript(NasmCase src, FS.FilePath dst)
        {
            var buffer = text.buffer();
            buffer.AppendLine("@echo off");
            buffer.AppendLineFormat("set SrcId={0}", src.CaseId);
            buffer.AppendLineFormat("set SrcPath={0}", format(src.SourcePath));
            buffer.AppendLineFormat("set BinPath={0}", format(src.BinPath));
            buffer.AppendLineFormat("set ListPath={0}", format(src.ListPath));
            buffer.AppendLineFormat("set tool={0}", format(ToolPath()));
            buffer.AppendLine("set CmdSpec=%tool% %SrcPath% -o %BinPath% -f bin -l %ListPath%");
            buffer.AppendLine("echo CmdSpec:%CmdSpec%");
            buffer.AppendLine("%CmdSpec%");
            dst.Overwrite(buffer.Emit());
            return script(src, dst);
        }
    }
}