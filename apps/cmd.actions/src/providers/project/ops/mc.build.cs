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