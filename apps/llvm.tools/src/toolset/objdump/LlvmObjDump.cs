//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using SQ = SymbolicQuery;

    [Tool(ToolId)]
    public sealed class LlvmObjDump : ToolService<LlvmObjDump>
    {
        public const string ToolId = LlvmNames.Tools.llvm_objdump;

        const string SectionMarker = "Disassembly of section ";

        const string FormatMarker = "file format ";

        public LlvmObjDump()
            : base(ToolId)
        {

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

        public Outcome Run(FS.FilePath src, FS.FolderPath dst)
        {
            var tool = LlvmNames.Tools.llvm_objdump;
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

        public Index<ObjDumpRow> Consolidated(FS.FilePath src)
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
                DataParser.parse(data[j++], out dst.Asm);
                DataParser.parse(data[j++], out dst.Source);
            }

            return buffer;
        }

        public Index<ObjDumpRow> Consolidated(ProjectId project)
        {
            var src = Ws.Project(project).Table<ObjDumpRow>(project.Format());
            return Consolidated(src);
        }

        public Outcome Consolidate(IProjectWs ws)
        {
            var src = ws.OutFiles(FileKind.ObjAsm).View;
            //var dst = ws.Table<ObjDumpRow>(ws.Project.Format());
            var dst = ProjectDb.TablePath<ObjDumpRow>("projects", ws.Project.Format());
            var result = Outcome.Success;
            var count = src.Length;
            var formatter = Tables.formatter<ObjDumpRow>(ObjDumpRow.RenderWidths);
            var flow = EmittingTable<ObjDumpRow>(dst);
            var total =0u;
            using var writer = dst.AsciWriter();
            writer.WriteLine(formatter.FormatHeader());
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                result = ParseDump(path, out var rows);
                if(result.Fail)
                {
                    Error(result.Message);
                    continue;
                }
                var counter = 0u;
                for(var j=0; j<rows.Length; j++)
                {
                    ref var row = ref seek(rows,j);
                    if(row.IsBlockStart)
                        continue;

                    row.Seq = counter++;
                    writer.WriteLine(formatter.Format(row));
                }
                total += counter;
            }
            EmittedTable(flow,total);
            return result;
        }

        public Outcome ParseDump(FS.FilePath src, out Span<ObjDumpRow> dst)
        {
            dst = default;
            var result = Outcome.Success;
            var section = EmptyString;
            var ParsingSection = false;
            var buffer = list<ObjDumpRow>();
            var row = ObjDumpRow.Empty();
            var blockaddress = MemoryAddress.Zero;
            var blockname = EmptyString;
            var data = src.ReadLines().Where(x => x != null).View;
            var format = EmptyString;
            var count = data.Length;
            var n = LineNumber.Empty;
            for(var x =0; x<data.Length; x++)
            {
                n++;
                var content = skip(data,x);

                if(empty(content))
                    continue;

                var m = text.index(content, FormatMarker);
                if(m >= 0)
                    format = text.right(content, m + FormatMarker.Length);

                var i = text.index(content, SectionMarker);
                if(i >= 0)
                {
                    var j = text.index(content,Chars.Colon);
                    if(j >=0)
                        section = text.inside(content, i + SectionMarker.Length - 1, j);
                    ParsingSection = true;
                    continue;
                }

                if(!ParsingSection)
                    continue;

                if(DefinesBlockLabel(content))
                {
                    var j = text.index(content, Chars.Lt);
                    if(j>=0)
                    {
                        row = ObjDumpRow.Empty();
                        row.Source = src;
                        row.Line = n;
                        row.Section = section;
                        var _address = text.left(content,j).Trim();
                        result = DataParser.parse(_address, out blockaddress);
                        if(result.Fail)
                        {
                            result = (false, AppMsg.ParseFailure.Format(nameof(row.BlockAddress), _address));
                            break;
                        }
                        row.BlockAddress = blockaddress;
                        row.IP = blockaddress;
                        row.Asm = ObjDumpRow.BlockStartMarker;

                        var k = text.index(content, Chars.Gt);
                        if(k>=0)
                        {
                            blockname = text.inside(content, j, k);
                            row.BlockName = blockname;
                        }
                        buffer.Add(row);
                        row = ObjDumpRow.Empty();
                    }
                }
                else
                {
                    var k = text.index(content, Chars.Colon);
                    if(k>=0)
                    {
                        row = ObjDumpRow.Empty();
                        row.Line = n;
                        row.Section = section;
                        row.Source = src;

                        var ip = text.left(content, k);
                        result = DataParser.parse(ip, out row.IP);
                        if(result.Fail)
                        {
                            result = (false, AppMsg.ParseFailure.Format(nameof(row.IP), ip));
                            break;
                        }
                        row.BlockAddress = blockaddress;
                        row.BlockName = blockname;
                        var asm = text.right(content, k);
                        var y = text.index(asm, Chars.Tab);
                        if(y > 0)
                        {
                            DataParser.parse(text.trim(text.left(asm, y)), out row.Encoding);
                            row.Asm = text.trim(text.right(asm, y)).Replace(Chars.Tab, Chars.Space);
                        }
                        buffer.Add(row);
                        row = ObjDumpRow.Empty();
                    }
                }
            }

            dst = buffer.Array();
            return result;
        }

        public Outcome DumpObjects(ReadOnlySpan<FS.FilePath> src, FS.FolderPath outdir, Action<CmdResponse> handler)
        {
            var count = src.Length;
            var tool = LlvmNames.Tools.llvm_objdump;

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
    }
}