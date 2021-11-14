//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed partial class XedTool : ToolService<XedTool>
    {
        public enum InputKind : byte
        {
            None = 0,

            [Symbol("-i", "pecoff-format")]
            PeCoff,


            [Symbol("-ir", "raw unformatted binary file")]
            RawBin,


            [Symbol("-ih", "raw unformatted ASCII hex file")]
            HexText,
        }

        public enum Mode : byte
        {
            None = 0,

            [Symbol("-r", "REAL_16 mode, 16b addressing (20b addresses), 16b default data size")]
            Real16,

            [Symbol("-r32", "REAL_32 mode, 16b addressing (20b addresses), 32b default data size")]
            Real32,

            [Symbol("-16", "LEGACY_16 mode, 16b addressing, 16b default data size")]
            Bits16,

            [Symbol("-32", "LEGACY_32 mode, 32b addressing, 32b default data size")]
            Bits32,

            [Symbol("-64", "LONG_64 mode w/64b addressing")]
            Bits64,
        }

        public XedTool()
            : base(Toolspace.xed)
        {

        }

        public XedCase DefineCase(string id, FS.FolderPath dst)
        {
            var @case = new XedCase();
            @case.CaseId = id;
            @case.InputPath = input(dst,  binfile(id));
            @case.SummaryPath = output(dst, ToolFile(id, "summary", FS.Log));
            @case.DetailPath =  output(dst, ToolFile(id, "detail", FS.Log));
            return @case;
        }

        public void AppendScript(XedCase src, ITextBuffer dst)
        {
            const string SummaryFlags = "-isa-set -64";
            const string DetailFlags = "-v 4 -isa-set -64";

            dst.AppendLine("@echo off");
            dst.AppendLineFormat("set tool={0}", format(ToolPath()));
            dst.AppendLineFormat("set case={0}", src.CaseId);
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

        // public ToolScript CreateScript(XedCase src)
        // {
        //     var buffer = text.buffer();
        //     AppendScript(src, buffer);
        //     return new ToolScript(Toolspace.xed, buffer.Emit());
        // }

        public string CreateScript(XedCase src)
        {
            var buffer = text.buffer();
            AppendScript(src, buffer);
            return buffer.Emit();
        }
    }
}