//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using Asm;

    using static Root;
    using static core;
    using static ProjectScriptNames;

    partial class ProjectCmdProvider
    {
        [CmdOp("mc/build")]
        Outcome BuildMc(CmdArgs args)
            => ProjectScripts.RunScript(Project(), EmptyString, McBuild, "asm");

        [CmdOp("mc/syntax")]
        Outcome McSyntax(CmdArgs args)
        {
            var src = LlvmMc.LoadSyntaxRows(Project());
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref src[i];
                ref readonly var syntax = ref row.Syntax;
                if(syntax.IsNonEmpty)
                {
                    ParseSyntaxParts(text.trim(text.despace(text.unfence(syntax,RenderFence.Paren))));
                }
            }

            return true;
        }


        void ParseSyntaxParts(string src)
        {
            var dst = text.buffer();

            var i = text.index(src,Chars.Comma);
            if(i > 0)
            {
                AsmMnemonic mnemonic = text.left(src,i);
                dst.Append(mnemonic.Format(MnemonicCase.Lowercase));

                var args = text.right(src, i + 1);
                dst.Append(" | ");
                dst.Append(args);
            }

            Write(dst.Emit());
        }
    }
}