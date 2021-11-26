//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using Asm;

    using static Root;
    using static core;

    using SQ = SymbolicQuery;
    using C = LlvmMc.LineClass;

    partial class LlvmMc
    {
        internal enum LineClass : byte
        {
            None,

            Empty,

            Directive,

            Label,

            AsmSource
        }

        public class LlvmMcParser : Service<LlvmMcParser>
        {
            public static Outcome parse(FS.FilePath src, out AsmDocument dst)
            {
                var parser = new LlvmMcParser();
                return parser.ParseSyntaxDoc(src, out dst);
            }

            List<AsmDirective> Directives;

            List<AsmBlockLabel> BlockLabels;

            List<LineNumber> BlockOffsets;

            List<AsmSourceLine> SourceLines;

            List<Identifier> Instructions;

            const string InstructionMarker = "<MCInst #";

            public Outcome ParseSyntaxDoc(FS.FilePath src, out AsmDocument dst)
            {
                var result = Outcome.Success;
                var data = FS.readlines(src).View;
                var count = (uint)data.Length;
                BlockLabels = new();
                BlockOffsets = new();
                SourceLines = new();
                Directives = new();
                Instructions = new();

                for(var i=0u; i<count; i++)
                    Parse(skip(data,i));

                dst = new AsmDocument(src,Directives.ToArray(), BlockLabels.ToArray(), BlockOffsets.ToArray(), SourceLines.ToArray(), Instructions.ToArray());
                return result;
            }

            void Parse(in TextLine src)
            {
                var @class = Classify(src);
                var content = src.Content.Replace(Chars.Tab, Chars.Space).Trim();
                switch(@class)
                {
                    case C.Label:
                        if(AsmParser.label(content, out AsmBlockLabel label))
                        {
                            BlockLabels.Add(label);
                            BlockOffsets.Add(src.LineNumber);
                            SourceLines.Add(new AsmSourceLine(src.LineNumber, label, EmptyString));
                        }
                    break;

                    case C.Directive:
                        if(AsmParser.directive(content, out var directive))
                        {
                            Directives.Add(directive);
                        }
                    break;

                    case C.AsmSource:
                        if(AsmParser.comment(src.Content, out var ilc))
                        {
                            var statement = text.left(content, (char)ilc.Marker);
                            if(statement.Length != 0)
                                statement = RP.Spaced4 + statement;

                            var comment = ilc.Content;

                            if(comment.Contains(InstructionMarker))
                            {
                                var i = text.index(comment, InstructionMarker) + InstructionMarker.Length;
                                var inst = text.remove(text.slice(comment,i),Chars.Gt);
                                var j = SymbolicQuery.wsindex(inst);
                                if(j != NotFound)
                                    Instructions.Add(text.right(inst,j));
                                else
                                    Instructions.Add(inst);
                            }

                            if(comment.Contains("encoding: "))
                            {
                                SourceLines.Add(new AsmSourceLine(src.LineNumber, EmptyString, statement));
                                SourceLines.Add(new AsmSourceLine(src.LineNumber, EmptyString, "#" + RP.Spaced2 + comment));
                            }
                            else if(comment.Contains(InstructionMarker) && statement.Length != 0)
                            {
                                SourceLines.Add(new AsmSourceLine(src.LineNumber, EmptyString, statement));
                                SourceLines.Add(new AsmSourceLine(src.LineNumber, EmptyString, "#" + RP.Spaced2 + comment));
                            }
                            else
                                SourceLines.Add(new AsmSourceLine(src.LineNumber, EmptyString, statement, comment));
                        }
                        else
                            SourceLines.Add(new AsmSourceLine(src.LineNumber, EmptyString, RP.Spaced4 + content));
                    break;
                }
            }

            static LineClass Classify(in TextLine src)
            {
                var content = src.Content.Trim();

                if(text.empty(content))
                    return C.Empty;

                if(IsLabel(content))
                    return C.Label;

                if(IsDirective(content))
                    return C.Directive;

                return C.AsmSource;
            }

            [MethodImpl(Inline)]
            static bool IsLabel(string src)
                => SQ.xedni(src, Chars.Colon) == src.Length - 1;

            [MethodImpl(Inline)]
            static bool IsDirective(string src)
                => SQ.index(src, Chars.Dot) == 0;
        }
    }
}