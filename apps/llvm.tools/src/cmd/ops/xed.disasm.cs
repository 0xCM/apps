//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using Asm;

    using static core;

    partial class LlvmCmd
    {
        const string XedDisasm = "xed/disasm";

        IntelXed Xed => Service(Wf.IntelXed);

        [CmdOp(XedDisasm)]
        Outcome ExecXedDisasm(CmdArgs args)
        {
            var project = Project();
            var paths = ProjectCollector.XedDisasmFiles(project);
            var count = paths.Length;
            var dst = text.buffer();
            var buffer = list<AsmStatementEncoding>();
            var counter = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref paths[i];
                var statements = ParseXedDisasm(path);
                var ecount = statements.Count;
                for(var j=0; j<ecount; j++)
                {
                    ref var statement = ref statements[j];
                    statement.Seq = counter++;
                    buffer.Add(statement);
                }
            }

            var outpath = project.Tables() + FS.file(string.Format("{0}.xed.disasm", project.Project), FS.Csv);
            TableEmit(buffer.ViewDeposited(), AsmStatementEncoding.RenderWidths, outpath);

            return true;
        }

        static Outcome ParseXedOffset(string src, out Address32 dst)
        {
            const string Marker = "XDIS ";
            var i = text.index(src,Marker);
            var j = Marker.Length - 1;
            var k = text.index(src, Chars.Colon);
            var length = k-j;
            var result = Outcome.Failure;
            dst = 0;
            if(j >= 0 && length > 0)
            {
                var spec = text.slice(src,j,length).Trim();
                result = DataParser.parse(spec, out dst);
            }
            return result;
        }

        static Outcome ParseXedEncoding(string src, out AsmHexCode dst)
        {
            var result = Outcome.Success;
            var digits = list<HexDigit>();
            var input = span(src);
            var length = input.Length;
            dst = AsmHexCode.Empty;
            for(var i=length-1; i>=0; i--)
            {
                ref readonly var c = ref skip(input,i);
                var test = Hex.test(c);
                if(!test)
                {
                    if(!test && digits.Count > 0)
                        break;

                    result = (false, string.Format("First digit not found in {0}", src));
                    break;
                }
            }

            if(result.Fail)
                return result;

            return result;
        }

        Index<AsmStatementEncoding> ParseXedDisasm(FS.FilePath src)
        {
            var xed = Service(Wf.IntelXed);
            var blocks = xed.ParseDisasmBlocks(src);
            var summaries = xed.SummaryLines(blocks);
            var expressions = xed.Expressions(blocks);
            var counter = 0u;
            var count = summaries.Length;
            var result = Outcome.Success;
            if(expressions.Length != count)
            {
                Error(string.Format("{0} != {1}", expressions.Length - 1, count));
                return default;
            }

            var buffer = list<AsmStatementEncoding>();
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(summaries,i);
                ref readonly var content = ref line.Content;
                var record = new AsmStatementEncoding();
                ref readonly var expression = ref skip(expressions,i);
                record.DocSeq = counter++;
                record.Asm = expression;
                record.Line = line.LineNumber;
                result = ParseXedOffset(content,out record.Offset);
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
                result = ParseXedEncoding(text.replace(content, expression.Content, string.Empty).Trim(), out record.Encoding);
                buffer.Add(record);
            }

            return buffer.ToArray();
        }
    }
}