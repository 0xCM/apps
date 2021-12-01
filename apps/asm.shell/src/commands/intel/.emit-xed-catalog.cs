//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;
    partial class AsmCmdService
    {
        [CmdOp(".emit-xed-isa")]
        Outcome XedIsa(CmdArgs args)
            => Xed.EmitIsa(arg(args,0).Value);

        [CmdOp(".emit-xed-catalog")]
        Outcome XedEmit(CmdArgs args)
        {
            var result = Outcome.Success;
            Xed.EmitCatalog();
            return result;
        }

        [CmdOp(".emit-disasm")]
        Outcome XedDisBlocks(CmdArgs args)
        {
            var result = Outcome.Success;
            var parser = Xed.DocParser();
            var src = FS.path(@"C:\Dev\ws\projects\mc.models\.out\asm\avx512blob.xed.txt");
            var blocks = parser.ParseDisasmBlocks(src);

            var count = blocks.Count;
            for(var i=0; i<count; i++)
            {
                var lines = blocks[i].Lines;
                var lcount = lines.Count;
                for(var j=0; j<lcount; j++)
                {
                    ref readonly var line = ref lines[j];
                    if(j == lcount-1)
                        Write(line.Format());
                }
            }

            return result;
        }

    }
}