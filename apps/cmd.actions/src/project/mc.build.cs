//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("mc/build")]
        Outcome BuildMc(CmdArgs args)
            => LlvmMc.Build(Project());

        [CmdOp("mc/syntax")]
        Outcome McSyntax(CmdArgs args)
        {
            var rows = LlvmMc.LoadSyntax(Project());
            var count = rows.Count;
            var opLists = LlvmMc.ExtractSyntaxOpLists(rows);
            Require.equal(count, opLists.Count);

            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref rows[i];
                ref readonly var oplist = ref opLists[i];
                var content = row.Syntax;
                Write(string.Format("{0,-8} | {1,-64} | {2}",
                    row.Seq,
                    row.Expr,
                    oplist.Delimit(Chars.Space)
                    ));
            }

            return true;
        }

        AsmRegSets Regs => Service(AsmRegSets.create);

        [CmdOp("mc/gen")]
        Outcome GenAsm(CmdArgs args)
        {
            // and              | r/m32, imm32                                                     | 81 /4 id
            const string SigOpCode = "and r32, imm32 | 81 /4 id";
            var buffer = text.buffer();
            var regs = Regs.Gp32Regs();
            var count = regs.Count;
            var pattern = "{0} {1}, 0x{2:x}";
            var inst = "and";
            var imm = 256u;
            buffer.AppendLine(AsmDirective.define("intel_syntax", "noprefix").Format());
            buffer.AppendLine();
            buffer.AppendLine(asm.comment(SigOpCode));
            buffer.AppendLine(new AsmBlockLabel("and_r32_imm32").Format());
            var indent = 4u;
            for(var i=0u; i<count; i++)
            {
                ref readonly var r = ref regs[i];
                var asm = string.Format(pattern, inst, r, imm++);
                if(i != count - 1)
                    buffer.IndentLine(indent,asm);
                else
                    buffer.Indent(indent,asm);
            }

            var dst = Project().SrcDir("asm") + FS.file(inst, FS.Asm);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            writer.WriteLine(buffer.Emit());
            EmittedFile(emitting,count);

            return true;
        }
   }
}