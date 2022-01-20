//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("seq/prod")]
        Outcome SeqProd(CmdArgs args)
        {
            var a = Intervals.closed(2u, 12u).Partition();
            var b = Intervals.closed(33u, 41u).Partition();
            var c = SeqProducts.mul(a,b);
            Write(SeqProducts.format(c));

            return true;
        }
        [CmdOp("sdm/productions")]
        Outcome SdmProductions(CmdArgs args)
        {
            var path = ProjectDb.Settings("asm.sigs.atomics", FS.ext("map"));
            var src = rules.atomics(path);
            foreach(var e in src.Entries)
            {
                var regs = e.Value;
                var expr = e.Key;
                Write(string.Format("{0} -> [{1}]", expr, regs));
            }
            return true;
        }

        [CmdOp("sdm/opcodes")]
        Outcome SdmOpCodes(CmdArgs args)
        {
            EmitSdmOpCodeDocs();
            return true;
        }

        void EmitSdmOpCodeDocs()
        {
            var codes = Sdm.LoadImportedOpCodes();
            var count = codes.Count;
            var buffer = alloc<AsmSigOpExpr>(12);
            var dst = ProjectDb.Subdir("sdm") + FS.file("sdm.opcodes.tables", FS.Txt);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();

            for(var i=0; i<count; i++)
            {
                buffer.Clear();
                ref readonly var entry = ref codes[i];
                ref readonly var sig = ref entry.Sig;
                ref readonly var opcode = ref entry.OpCode;
                var opcount = sig.Operands(buffer);
                writer.WriteLine(string.Format("{0,-8} | {1,-64} | {2,-36}", entry.OpCodeKey, sig.Format(), opcode.Expr.Format()));
                for(var j=0; j<opcount; j++)
                {
                    ref readonly var op = ref skip(buffer,j);
                    writer.WriteLine(string.Format("       {0} | {1}", j, op.Format()));
                }
            }
            EmittedFile(emitting,count);
        }
   }
}