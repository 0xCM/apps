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
        [CmdOp("sdm/productions")]
        Outcome SdmProductions(CmdArgs args)
        {
            var path = ProjectDb.Settings("asm.sigs.atomics", FS.ext("map"));
            var src = rules.atomics(path);
            foreach(var e in src.Entries)
            {
                Write(string.Format("{0} -> [{1}]", e.Key, e.Value));
            }
            return true;
        }

        [CmdOp("sdm/opcodes")]
        Outcome SdmOpCodes(CmdArgs args)
        {
            var codes = Sdm.LoadImportedOpCodes();
            var count = codes.Count;
            var buffer = alloc<AsmSigOpExpr>(12);
            var dst = text.buffer();

            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                ref readonly var entry = ref codes[i];
                ref readonly var sig = ref entry.Sig;
                ref readonly var opcode = ref entry.OpCode;
                var opcount = sig.Operands(buffer);
                dst.AppendLineFormat("{0,-64} | {1,-36}", sig.Format(), opcode.Expr.Format());
                for(var j=0; j<opcount; j++)
                {
                    ref readonly var op = ref skip(buffer,j);
                    dst.AppendLineFormat("  {0} {1}", j, op.Format());
                }

                Write(dst.Emit());
            }

            return true;
        }
   }
}