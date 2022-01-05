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
                    var parts = text.split(text.unfence(syntax,RenderFence.Paren), Chars.Comma);
                    ParseSyntaxParts(parts);
                }
            }

            return true;
        }

        void ParseSyntaxParts(ReadOnlySpan<string> src)
        {
            var count = src.Length;
            var dst = text.buffer();
            if(!src.IsEmpty)
            {
                AsmMnemonic mnemonic = first(src);
                dst.AppendFormat("{0,-16}", mnemonic.Format(MnemonicCase.Lowercase));
                for(var i=1; i<count; i++)
                {
                    ref readonly var part = ref skip(src,i);
                    dst.AppendFormat(" | {0,-12}", part);
                }

                Write(dst.Emit());
            }

        }
    }
}