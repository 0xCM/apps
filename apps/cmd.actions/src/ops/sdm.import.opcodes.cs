//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    using static core;

    partial class GlobalCommands
    {
        [CmdOp("sdm/import/opcodes")]
        Outcome SdmCodeGen(CmdArgs args)
        {
            var result = Outcome.Success;
            var opcodes = Sdm.ImportOpCodes();
            var ops = operands(opcodes);
            var count = ops.Count;

            for(var i=0; i<count; i++)
            {
                var op = ops[i];
                Write(string.Format("{0} -> {1}", op, op));
            }
            return result;
        }

        static Index<string> operands(ReadOnlySpan<SdmOpCodeDetail> src)
        {
            var count = src.Length;
            var dst = hashset<string>();
            for(var i=0; i<count; i++)
            {
                ref readonly var opcode = ref skip(src,i);
                var sigtext = text.despace(text.trim(opcode.Sig.Format()));
                var j = text.index(sigtext,Chars.Space);
                if(j > 0)
                {
                    var ops = text.trim(text.split(text.right(sigtext,j), Chars.Comma));
                    for(var k = 0; k<ops.Length; k++)
                        dst.Add(skip(ops,k));
                }
            }
            return dst.Array().Sort();
        }
   }
}