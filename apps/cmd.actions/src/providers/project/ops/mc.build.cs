//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using Asm;

    using static core;
    using static Root;

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
            var ops = LlvmMc.ExtractSyntaxOpLists(rows);
            Require.equal(count,ops.Count);
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref rows[i];
                ref readonly var op = ref ops[i];
                var content = row.Syntax;
                var mnemonic = AsmMnemonic.parse(content, out _);
                var opkinds = op.OpClasses.Count != 0 ? string.Format("<{0}>", op.OpClasses.Delimit(Chars.Comma).Format()) : EmptyString;

                Write(string.Format("{0,-8} | {1,-18} | {2,-42} | {3}",
                    row.Seq,
                    mnemonic.Format(MnemonicCase.Lowercase),
                    opkinds,
                    content)
                    );
            }

            return true;
        }

        AsmRegSets Regs => Service(Wf.AsmRegSets);

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
            buffer.AppendLine(asm.directive("intel_syntax", "noprefix").Format());
            buffer.AppendLine();
            buffer.AppendLine(asm.comment(SigOpCode));
            buffer.AppendLine(asm.label("and_r32_imm32").Format());
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

            var dst = Project().Src("asm") + FS.file(inst, FS.Asm);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            writer.WriteLine(buffer.Emit());
            EmittedFile(emitting,count);

            return true;
        }


        bool ExtractMemOp(string src, out string dst)
        {
            const string Marker = "Memory:";
            dst = EmptyString;
            var result = false;
            var i = text.index(src, "Memory:");
            if(i >= 0)
            {
                dst = src;
                result = true;
                var x = text.left(src,i + Marker.Length + 1);
                var j = text.index(x, Chars.Colon);
                if(j > 0)
                {
                    var left = text.left(x, Chars.Colon);
                    i = text.xedni(left,Chars.Space);
                    if(i > 0)
                    {
                        dst = text.left(left,i);
                    }
                }
            }
            return result;
        }

        [CmdOp("cmdlog/parse")]
        Outcome ParseCmdLog(CmdArgs args)
        {
            var project = Project();
            var src = project.Out() + FS.file("commands", FileKind.Log.Ext());
            using var reader = src.Utf8LineReader();
            while(reader.Next(out var line))
            {
                var content = text.trim(line.Content);
            }
            return true;
        }
   }
}