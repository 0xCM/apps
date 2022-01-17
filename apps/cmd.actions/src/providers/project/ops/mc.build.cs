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
            var src = LlvmMc.LoadSyntax(Project());
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var row = ref src[i];
                ref readonly var syntax = ref row.Syntax;
                if(syntax.IsNonEmpty)
                {
                    var dst = text.buffer();
                    var input = text.trim(text.despace(text.unfence(syntax,RenderFence.Paren)));
                    var mnemonic = ParseMnemonic(input, out var mx);
                    var optext = EmptyString;
                    if(mx > 0)
                        optext = text.right(input,mx);

                    var indices = text.indices(optext, Chars.Colon);
                    var ixcount = indices.Count;
                    for(var j=0; j<ixcount; j++)
                    {
                        ref readonly var k = ref indices[j];
                        if(j == 0)
                        {
                            dst.Append(text.left(optext, k));
                        }
                        else
                        {
                            ref readonly var p = ref indices[j-1];
                            var xx = text.inside(optext, p, k);
                            var m = text.xedni(xx,Chars.Space);
                            var yy = text.right(xx,m);
                            if(yy.Contains(Chars.LBrace))
                            {
                                yy = "RegMask";
                            }
                            dst.Append(string.Format(" | {0}", yy));
                        }
                    }

                    var classes = dst.Emit();
                    if(text.nonempty(classes))
                        Write(string.Format("{0,-20} | {1,-40} | {2}", mnemonic.Format(MnemonicCase.Lowercase), classes, input));
                    else
                        Write(mnemonic.Format(MnemonicCase.Lowercase));
                }
            }

            return true;
        }

        static AsmMnemonic ParseMnemonic(string src, out int i)
        {
            i = text.index(src,Chars.Comma,Chars.Space);
            if(i>0)
            {
                return text.left(src,i);
            }
            else
                return src;
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

        Index<string> ParseArgs(string src)
        {
            var indices = text.indices(src,Chars.Colon);
            var count = indices.Length;
            if(count == 0)
                return sys.empty<string>();
            var dst = alloc<string>(count);
            for(var i=0; i<count - 1; i++)
            {
                ref readonly var j = ref indices[i];
                ref readonly var k = ref indices[i+1];
                seek(dst,i) = text.inside(src,j,k);
            }
            seek(dst,count - 1) = text.right(src, indices[count - 1]);
            return dst;
        }

        void ParseSyntaxParts(string src)
        {
            var dst = text.buffer();

            var i = text.index(src,Chars.Comma);
            if(i > 0)
            {
                AsmMnemonic mnemonic = text.left(src,i);
                dst.Append(mnemonic.Format(MnemonicCase.Lowercase));
                //var args = text.right(src, i + 1);
                var args = ParseArgs(text.right(src, i+1));
                dst.Append(" | ");
                dst.Append(args.Delimit(Chars.Pipe).Format());
            }

            Write(dst.Emit());
        }

        static string Args(string src)
        {
            var i = text.index(src,Chars.Comma);
            var args = EmptyString;
            if(i > 0)
            {
                args = text.right(src, i+1);
            }
            return args;
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