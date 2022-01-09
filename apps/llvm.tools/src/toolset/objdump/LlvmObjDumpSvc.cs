//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using Asm;

    using static Root;
    using static core;

    using SQ = SymbolicQuery;

    class LlvmObjDumpParser
    {
        const string SectionMarker = "Disassembly of section ";

        FS.FileUri Source;

        ObjDumpRow Row;

        TextBlock Section;

        bool ParsingSection;

        DataList<ObjDumpRow> Buffer;

        MemoryAddress BlockAddress;

        TextBlock BlockName;

        LineNumber N;

        public LlvmObjDumpParser()
        {
            Reset();
        }

        void Reset()
        {
            Row = ObjDumpRow.Empty();
            Section = EmptyString;
            Buffer = new();
            ParsingSection = false;
            BlockAddress = MemoryAddress.Zero;
            BlockName = EmptyString;
            N = LineNumber.Empty;
        }

        public Outcome ParseSource(FS.FilePath src, out Index<ObjDumpRow> dst)
        {
            var result = Outcome.Success;
            dst = sys.empty<ObjDumpRow>();
            Reset();

            var data = src.ReadLines().Where(x => x != null).View;
            var count = data.Length;
            for(var x =0; x<count; x++)
            {
                N++;

                var content = skip(data,x);
                if(empty(content))
                    continue;

                var i = text.index(content, SectionMarker);
                if(i >= 0)
                {
                    var j = text.index(content,Chars.Colon);
                    if(j >=0)
                        Section = text.inside(content, i + SectionMarker.Length - 1, j);
                    ParsingSection = true;
                    continue;
                }

                if(!ParsingSection)
                    continue;

                if(DefinesBlockLabel(content))
                {
                    result = ParseBlockLabel(content);
                    if(result.Fail)
                        break;

                    Buffer.Add(Row);
                    Row = ObjDumpRow.Empty();
                }
                else
                {
                    var k = text.index(content, Chars.Colon);
                    if(k>=0)
                    {
                        Row = ObjDumpRow.Empty();
                        Row.Line = N;
                        Row.Section = Section;
                        Row.Source = src;
                        result = DataParser.parse(text.left(content, k), out Row.IP);
                        if(result.Fail)
                        {
                            result = (false, AppMsg.ParseFailure.Format(nameof(Row.IP), content));
                            break;
                        }
                        Row.BlockAddress = BlockAddress;
                        Row.BlockName = BlockName;
                        var asm = text.right(content, k);
                        var y = text.index(asm, Chars.Tab);
                        if(y > 0)
                        {
                            DataParser.parse(text.trim(text.left(asm, y)), out Row.Encoding);
                            var statement = text.trim(text.right(asm, y)).Replace(Chars.Tab, Chars.Space);
                            Row.Statement = statement;
                            if(AsmParser.comment(statement, out Row.Comment))
                            {
                                var m = text.index(statement, Chars.Hash);
                                if(m>0)
                                    Row.Statement = text.left(statement, m);
                            }
                        }
                        Buffer.Add(Row);
                        Row = ObjDumpRow.Empty();
                    }
                }
            }

            dst = Buffer.Array();
            return result;
        }

        Outcome ParseBlockLabel(string content)
        {
            var result = Outcome.Success;
            var j = text.index(content, Chars.Lt);
            if(j >=0)
            {
                Row.Source = Source;
                Row.Line = N;
                Row.Section = Section;
                Row.Encoding = BinaryCode.Empty;
                Row.Statement = ObjDumpRow.BlockStartMarker;
                var k = text.index(content, Chars.Gt);
                if(k>=0)
                    Row.BlockName = text.inside(content, j, k);

                var ip = text.left(content, j).Trim();
                result = DataParser.parse(ip, out Row.BlockAddress);
                if(result.Fail)
                    result = (false, AppMsg.ParseFailure.Format(nameof(Row.BlockAddress), ip));
                else
                    Row.IP = Row.BlockAddress;

                BlockName = Row.BlockName;
                BlockAddress = Row.BlockAddress;
            }
            else
            {
                result = (false, AppMsg.ParseFailure.Format("BlockMarker", content));
            }
            return result;
        }

        static bool DefinesBlockLabel(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var result = false;
            var gt = -1;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(i <16 && SQ.digit(base16,c))
                    continue;

                if(i == 16 && SQ.whitespace(c))
                    continue;

                if(i == 17 && SQ.lt(c))
                    continue;

                if(i > 17 && SQ.gt(c))
                    gt = i;

                if(gt > 0 && i == gt + 1 && SQ.colon(c))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }

    [Tool(ToolId)]
    public sealed class LlvmObjDumpSvc : ToolService<LlvmObjDumpSvc>
    {
        public const string ToolId = ToolNames.llvm_objdump;

        const string SectionMarker = "Disassembly of section ";

        const string FormatMarker = "file format ";

        public LlvmObjDumpSvc()
            : base(ToolId)
        {

        }

        public Outcome Run(FS.FilePath src, FS.FolderPath dst)
        {
            var tool = ToolNames.llvm_objdump;
            var cmd = Cmd.cmdline(Ws.Tools().Script(tool, "run").Format(PathSeparator.BS));
            var vars = WsVars.create();
            vars.DstDir = dst;
            vars.SrcDir = src.FolderPath;
            vars.SrcFile = src.FileName;
            var result = OmniScript.Run(cmd, vars.ToCmdVars(), out var response);
            if(result)
            {
               var items = ParseCmdResponse(response);
               iter(items, item => Write(item));
            }
            return result;
        }

        public Index<AsmCode> ExtractAsmCode(FS.FilePath src)
        {
            var rows = LoadConsolidated(src);
            var count = rows.Length;

            return default;
        }

        public Index<ObjDumpRow> LoadConsolidated(FS.FilePath src)
        {
            var result = TextGrids.load(src, TextEncodingKind.Asci, out var grid);
            if(result.Fail)
            {
                Error(result.Message);
                return sys.empty<ObjDumpRow>();
            }

            var count = grid.RowCount;
            var buffer = alloc<ObjDumpRow>(count);
            ref var target = ref first(buffer);
            for(var i=0u; i<count; i++)
            {
                ref readonly var data = ref grid[(int)i];
                ref var dst = ref seek(target,i);
                var j=0;
                DataParser.parse(data[j++], out dst.Seq);
                DataParser.parse(data[j++], out dst.Line);
                DataParser.parse(data[j++], out dst.Section);
                DataParser.parse(data[j++], out dst.BlockAddress);
                DataParser.parse(data[j++], out dst.BlockName);
                DataParser.parse(data[j++], out dst.IP);
                DataParser.parse(data[j++], out dst.Encoding);
                DataParser.parse(data[j++], out dst.Statement);
                AsmParser.comment(data[j++].View, out dst.Comment);
                DataParser.parse(data[j++], out dst.Source);
            }

            return buffer;
        }


        public Outcome Consolidate(IProjectWs project)
        {
            var src = project.OutFiles(WfFileKind.ObjAsm).View;
            var dst = ProjectDb.ProjectTable<ObjDumpRow>(project);
            var result = Outcome.Success;
            var count = src.Length;
            var formatter = Tables.formatter<ObjDumpRow>(ObjDumpRow.RenderWidths);
            var flow = EmittingTable<ObjDumpRow>(dst);
            var emitted = list<ObjDumpRow>();
            var total =0u;
            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                result = ParseDumpSource(path, out var rows);
                if(result.Fail)
                {
                    Error(result.Message);
                    continue;
                }

                var counter = 0u;
                for(var j=0; j<rows.Length; j++)
                {
                    ref var row = ref rows[j];
                    if(row.IsBlockStart)
                        continue;

                    row.Seq = counter++;
                    writer.WriteLine(formatter.Format(row));
                    emitted.Add(row);
                }
                total += counter;
            }
            EmittedTable(flow, total);
            return result;
        }

        public Outcome ParseDumpSource(FS.FilePath src, out Index<ObjDumpRow> dst)
        {
            var parser = new LlvmObjDumpParser();
            return parser.ParseSource(src, out dst);
        }

        public Outcome DumpObjects(ReadOnlySpan<FS.FilePath> src, FS.FolderPath outdir, Action<CmdResponse> handler)
        {
            var count = src.Length;
            var tool = ToolNames.llvm_objdump;
            var cmd = Cmd.cmdline(Ws.Tools().Script(tool, "run").Format(PathSeparator.BS));
            var result = Outcome.Success;
            var responses = list<CmdResponse>();
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                var vars = WsVars.create();
                vars.DstDir = outdir;
                vars.SrcDir = path.FolderPath;
                vars.SrcFile = path.FileName;
                result = Run(cmd, vars.ToCmdVars(), out var lines);
                if(result.Fail)
                    break;

                var len = lines.Length;
                for(var j=0; j<len; j++)
                {
                    if(CmdResponse.parse(skip(lines,j).Content, out var response))
                        handler(response);
                }
            }
            return result;
        }

        public void Recode(IProjectWs srcProject)
        {
            var dstProject = Ws.Project(ProjectNames.McRecoded);
            var srcTable = ProjectDb.ProjectTable<ObjDumpRow>(srcProject);
            var rows = LoadConsolidated(srcTable);
            var count = rows.Length;
            var srcid = EmptyString;
            var block = EmptyString;
            var dstdir = dstProject.SrcDir(srcProject.Project.Format());
            var dstpath = FS.FilePath.Empty;
            var emitting = default(WfFileFlow);
            var lines = list<string>();
            var label = AsmLabel.Empty;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref rows[i];
                var _srcid = FS.path(row.Source.WithoutLine.Format()).SrcId(WfFileKind.ObjAsm);

                if(empty(srcid))
                {
                    srcid = _srcid;
                    dstpath = dstdir + FS.file(srcid, WfFileKind.Asm.Ext());
                    lines.Add(".intel_syntax noprefix");
                    emitting = EmittingFile(dstpath);
                }
                else if(srcid != _srcid)
                {
                    if(lines.Count != 0)
                    {
                        using var writer = dstpath.AsciWriter();
                        iter(lines, line => writer.WriteLine(line));
                        EmittedFile(emitting, lines.Count);
                    }
                    lines.Clear();
                    lines.Add(".intel_syntax noprefix");
                    srcid = _srcid;
                    dstpath = dstdir + FS.file(srcid, WfFileKind.Asm.Ext());
                    EmittingFile(dstpath);
                }

                var _block = row.BlockName;
                if(empty(block) || block !=_block)
                {
                    if(nonempty(block))
                        lines.Add(EmptyString);
                    block = _block;
                    label = asm.label(block);
                    lines.Add(label.Format());
                    continue;
                }

                if(row.Statement.IsNonEmpty)
                    lines.Add(string.Format("    {0}", row.Statement));
            }

            if(lines.Count != 0)
            {
                using var writer = dstpath.AsciWriter();
                iter(lines, line => writer.WriteLine(line));
                EmittedFile(emitting, lines.Count);
            }
        }
    }
}