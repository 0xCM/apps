//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using static core;

    partial class AsmCmdService
    {
        [CmdOp("sdm/import/opcodes")]
        Outcome SdmCodeGen(CmdArgs args)
        {
            var opcodes = Sdm.ImportOpCodes();
            // var items = ExtractOpCodeStrings(opcodes);
            // var dst = Generators.CodeGenDir("intel");
            return true;
        }

        static Index<ListItem<string>> ExtractOpCodeStrings(ReadOnlySpan<SdmOpCode> src)
        {
            var count = src.Length;
            var items = list<string>(count);
            var counter = 0u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var detail = ref skip(src,i);
                var fmt = detail.Expr.Format().Trim();
                if(nonempty(fmt))
                {
                    items.Add(fmt);
                    counter++;
                }

            }
            items.Sort();
            return items.ToArray().Mapi((i,x) => new ListItem<string>((uint)i,x));
        }
    }
}