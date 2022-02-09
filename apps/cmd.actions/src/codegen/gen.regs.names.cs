//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using System.IO;

    using static core;

    partial class CodeGenProvider
    {
        [CmdOp("gen/symspan")]
        Outcome EmitSymSpan(CmdArgs srgs)
        {
            var result = Outcome.Success;
            var dst = ProjectDb.Logs() + FS.folder("cs") + FS.file("symspan", FS.Cs);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            EmitSymSpan<AsciLetterLoSym>("AsciLetterLoSym", writer);
            EmittedFile(emitting, 1);
            return result;
        }

        void EmitSymSpan<E>(Identifier container, StreamWriter dst)
            where E : unmanaged, Enum
        {
            var buffer = text.buffer();
            SpanResGen.symrender<E>(container, buffer);
            dst.WriteLine(buffer.Emit());
        }

        [CmdOp("gen/regs/names")]
        Outcome EmitRegNames(CmdArgs args)
        {
            var dst = ProjectDb.Logs() + FS.folder("cs") + FS.file("regnames", FS.Cs);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var regs = AsmRegData.gp();
            var count = regs.Length;
            var buffer = text.buffer();
            for(var i=0; i<count; i++)
            {
                if(i != 0 && i%4 == 0)
                    buffer.AppendLine();

                ref readonly var reg = ref skip(regs,i);
                buffer.AppendFormat("{0,-6}", reg);
            }
            var bytes = SpanRes.specify("GpRegNames", recover<RegOp,byte>(regs).ToArray());
            writer.WriteLine(SpanResFormatter.format(bytes));
            EmittedFile(emitting, regs.Length);
            return true;
        }
    }
}