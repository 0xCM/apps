//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class CheckCmdProvider
    {
        [CmdOp("check/asm/jcc")]
        Outcome CheckJcc(CmdArgs args)
        {
            var @case = AsmCaseAssets.create().Branches();
            Utf8.decode(@case.ResBytes, out var doc);
            using var dispenser = AsmDispenser.create();
            var parser = DecodedAsmParser.create(dispenser);
            var result = parser.ParseBlocks(doc);
            var blocks = parser.Parsed();
            var view = blocks.View;
            var count = view.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var block = ref skip(view,i);
                Write(block.Label.Name);
                var statements = block.Statements;
                var kS = statements.Count;
                for(var j=0; j<kS; j++)
                {
                    ref readonly var statement = ref statements[j];
                    ref readonly var encoded = ref statement.Encoded;
                    ref readonly var decoded = ref statement.Decoded;
                    Write(statement.Format());
                }
            }

            return result;
        }


    }
}