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
        [CmdOp(".xed-disasm")]
        Outcome XedDisasm(CmdArgs args)
        {
            var paths = ProjectCollector.XedDisasmFiles(Project());
            var count = paths.Length;
            var xed = Wf.IntelXed();
            var dst = text.buffer();
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref paths[i];
                var encoding = ParseXedDisasm(path);
            }

            return true;
        }

        Index<AsmStatementEncoding> ParseXedDisasm(FS.FilePath src)
        {
            var xed = Service(Wf.IntelXed);
            var blocks = xed.ParseDisasmBlocks(src);
            var summaries = xed.SummaryLines(blocks);
            var expressions = xed.Expressions(blocks);

            var count = summaries.Length;
            if(expressions.Length != count)
            {
                Error(string.Format("{0} != {1}", expressions.Length, count));
            }
            var buffer = list<AsmStatementEncoding>();
            for(var i=0; i<count; i++)
            {
                ref readonly var line = ref skip(summaries,i);
                ref readonly var content = ref line.Content;
                var j = text.index(content, "XDIS ");
                var k = text.index(content, Chars.Colon);
                if(j >=0 && k > j)
                {
                    var _offset = text.inside(content,j,k);
                    var record = new AsmStatementEncoding();
                    DataParser.parse(_offset, out Address32 offset);
                }

                Write(skip(expressions,i));
            }


            return default;
        }
    }
}